using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    #region Variables
    public TimerController scptActiveTimer;
    public GUIScript scptGUI;
    public bool bGamePaused = true;
    public bool bGameFinnish = false;
    #endregion

    #region Singleton
    public static GameController Instance { get; private set; }
    private void Awake() {
        if (Instance == null) Instance = this;
    }
    #endregion



    private float fCurrentTime = 0;
    private float fDelayTime = 1;
    private void Update() {
        if (bGameFinnish) {
            fCurrentTime += Time.deltaTime;
            if (fCurrentTime>= fDelayTime) {
                scptGUI.FinnishUI();
            }
        }
    }
}
