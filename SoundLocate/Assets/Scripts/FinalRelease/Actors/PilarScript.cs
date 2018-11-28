using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarScript : MonoBehaviour {

    public List<PilarScript> scrpPilarsProximity;
    public bool bSoundPilar;
    public AudioSource asSound;


    private float fCurrentTime = 0;
    public float fDelayTime = 2;

    private enum eResult {
        FAIL = 0,
        PROXIMITY = 1,
        SUCCESS = 2
    }

	// Use this for initialization
	void Start () {
        //GameController.Instance.listscrPilars.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (bSoundPilar) {
            fCurrentTime += Time.deltaTime;
            if (fCurrentTime >= fDelayTime) {
                PlaySound();
                fCurrentTime = 0;
            }
        }
    }
    public void PlaySound() {
        asSound.Play();
    }

    public void SelectPilar() {
        bool bReport = false;
        if (bSoundPilar) {
            bReport = true;
            ShowResultSelection(eResult.SUCCESS);
            GameController.Instance.scptActiveTimer.bFinnish = true;
        }
        if (!bReport) {
            foreach (PilarScript scrpPilar in scrpPilarsProximity) {
                if (scrpPilar.bSoundPilar) {
                    bReport = true;
                    ShowResultSelection(eResult.PROXIMITY);
                }
            }
            if (!bReport) ShowResultSelection(eResult.FAIL);
        }
    }

    private void ShowResultSelection(eResult _eResult) {
        //Cambiar materiales al color que sea.
        switch (_eResult) {
            case eResult.FAIL: Debug.Log("FAIL"); break;
            case eResult.PROXIMITY: Debug.Log("PROXIMITY"); break;
            case eResult.SUCCESS: Debug.Log("SUCCESS"); break;
        }
    }

    public void SetSoundInPilar() {
        bSoundPilar = true;
    }

    public void ResetPilar() {
        bSoundPilar = false;
    }
}
