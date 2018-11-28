using UnityEngine;

public class SelectorPilar : MonoBehaviour {

    private PilarScript scrptPilar;

    private void Start() {
        scrptPilar = gameObject.GetComponent<PilarScript>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag.Equals("Player")) {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                
                scrptPilar.SelectPilar();

            }
        }
    }
}
