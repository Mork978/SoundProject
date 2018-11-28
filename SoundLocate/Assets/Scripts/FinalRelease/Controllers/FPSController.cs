using UnityEngine;

public class FPSController : MonoBehaviour {
    
    #region Variables
    //Rotation
    [Header("Controller - Rotation")]
    public float fYawAngleRotationalSpeed = 360.0f;
    public float fPitchAngleRotationalSpeed = 180.0f;
    public float fMinPitchAngle = -80.0f;
    public float fMaxPirchAngle = 50.0f;
    public Transform trsfrmPitchController;
    public bool bInvertedYawAngle = false;
    public bool bInvertedPitchAngle = false;
    public float fYawAngle;
    private float fPitchAngle;

    //Movement
    [Header("Controller - Movement")]
    public CharacterController chctrCharacterController;
    public float fSpeed = 10.0f;
    public KeyCode kyLeftKeyCode = KeyCode.A;
    public KeyCode kyRightKeyCode = KeyCode.D;
    public KeyCode kyUpKeyCode = KeyCode.W;
    public KeyCode kyDownKeyCode = KeyCode.S;

    //Gravity
    [Header("Controller - Gravity")]
    float fVerticalSpeed = 0.0f;
    //bool bOnGround = false;

    //Run
    [Header("Controller - Run")]
    public KeyCode kyRunKeyCode = KeyCode.LeftShift;
    public float fFastSpeedMultiplier = 1.2f;

    //Jump
    [Header("Controller - Jump")]
    public KeyCode kyJumpKeyCode = KeyCode.Space;
    public float fJumpSpeed = 10.0f;

    //Lock Cursor - Debug
    [Header("Controller - Debug")]
    public KeyCode kyDebugLockAimKeyCode = KeyCode.I;
    public KeyCode kyDebugLockKeyCode = KeyCode.O;
    bool bAimLocked = false;

    public Transform trnsfrmParent;
    public bool bGameOver = false;
    #endregion

    #region Methods
    void Awake() {
        fYawAngle = transform.rotation.eulerAngles.y;
        fPitchAngle = trsfrmPitchController.localRotation.eulerAngles.x;
    }

    private void Start() {
        trnsfrmParent = transform.parent;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update() {
        if (!GameController.Instance.bGamePaused) {
            //Debug
            if (Input.GetKeyDown(kyDebugLockAimKeyCode)) bAimLocked = !bAimLocked;
            if (Input.GetKeyDown(kyDebugLockKeyCode)) {
                if (Cursor.lockState == CursorLockMode.Locked)
                    Cursor.lockState = CursorLockMode.None;
                else
                    Cursor.lockState = CursorLockMode.Locked;
            }
            if (!bAimLocked) {
                //Rotation
                float fMouseAxisY = Input.GetAxis("Mouse Y");
                if (bInvertedPitchAngle) fMouseAxisY = -fMouseAxisY;
                fPitchAngle = fPitchAngle + fMouseAxisY * fPitchAngleRotationalSpeed * Time.deltaTime;
                fPitchAngle = Mathf.Clamp(fPitchAngle, fMinPitchAngle, fMaxPirchAngle);

                float fMouseAxisX = Input.GetAxis("Mouse X");
                if (bInvertedYawAngle) fMouseAxisX = -fMouseAxisX;
                fYawAngle = fYawAngle + fMouseAxisX * fYawAngleRotationalSpeed * Time.deltaTime;

                transform.rotation = Quaternion.Euler(0.0f, fYawAngle, 0.0f);
                trsfrmPitchController.localRotation = Quaternion.Euler(fPitchAngle, 0.0f, 0.0f);
            }

            //Movement
            float fYawAngleInRadians = fYawAngle * Mathf.Deg2Rad;
            float fYawAngle90InRadians = (fYawAngle + 90.0f) * Mathf.Deg2Rad;
            Vector3 v3Movement = Vector3.zero;
            Vector3 v3Forward = new Vector3(Mathf.Sin(fYawAngleInRadians), 0.0f, Mathf.Cos(fYawAngleInRadians));
            Vector3 v3Right = new Vector3(Mathf.Sin(fYawAngle90InRadians), 0.0f, Mathf.Cos(fYawAngle90InRadians));
            if (Input.GetKey(kyUpKeyCode)) {
                v3Movement += v3Forward;
            } else if (Input.GetKey(kyDownKeyCode)) {
                v3Movement -= v3Forward;
            }
            if (Input.GetKey(kyRightKeyCode)) {
                v3Movement += v3Right;
            } else if (Input.GetKey(kyLeftKeyCode)) {
                v3Movement -= v3Right;
            }
            v3Movement.Normalize();

            //Run
            float fSpeedMultiplier = 1.0f;
            if (Input.GetKey(kyRunKeyCode)) fSpeedMultiplier = fFastSpeedMultiplier;
            v3Movement = v3Movement * Time.deltaTime * fSpeed * fSpeedMultiplier;

            //Gravity
            fVerticalSpeed += Physics.gravity.y * Time.deltaTime;

            //Jump
            //if (bOnGround && Input.GetKeyDown(kyJumpKeyCode)) fVerticalSpeed = fJumpSpeed;

            v3Movement.y = fVerticalSpeed * Time.deltaTime;
            CollisionFlags cllfCollisionFlags = chctrCharacterController.Move(v3Movement);
            if ((cllfCollisionFlags & CollisionFlags.Below) != 0) {
                //bOnGround = true;
                fVerticalSpeed = 0.0f;
            } else {
                //bOnGround = false;
            }
            if ((cllfCollisionFlags & CollisionFlags.Above) != 0 && fVerticalSpeed > 0.0f) {
                fVerticalSpeed = 0.0f;
            }
        }
    }
    #endregion

}
