using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    public Text txtTimerActive;
    public Text txtTimerOther;
    public Text txtRound;
    public GameObject gobjStartUI;
    public GameObject gonjWinPlayer1;
    public GameObject gonjWinPlayer2;




    // Use this for initialization
    void Start () {
        gonjWinPlayer1.SetActive(false);
        gonjWinPlayer2.SetActive(false);
        /*txtTimerActive.text = (GamesController.GetTimerActivePlayer(GamesController.GetPlayer()) + GamesController.GetTimeRound()).ToString();
        txtTimerOther.text = (GamesController.GetTimerDeactivePlayer(GamesController.GetPlayer()) + GamesController.GetTimeRound()).ToString();*/
        txtTimerActive.text = GamesController.GetTimerActivePlayer(GamesController.GetPlayer()).ToString("0.00");
        txtTimerOther.text = GamesController.GetTimerDeactivePlayer(GamesController.GetPlayer()).ToString("0.00");
        txtRound.text = GamesController.GetRoundCounter().ToString();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug Inputs
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GamesController.ShowStatus();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GamesController.NextRound();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (GameController.Instance.bGameFinnish) {
                Debug.Log("Go To Menu");
            } else if(GameController.Instance.bGamePaused) {
                GameController.Instance.bGamePaused = false;
                GameController.Instance.scptActiveTimer.ActiveTimer();
                gobjStartUI.SetActive(false);
            }
        }
    }

    public void FinnishUI() {
        switch (GamesController.GetPlayer()) {
            case GamesController.ePLAYER.PLAYER1: gonjWinPlayer2.SetActive(true); break;
            case GamesController.ePLAYER.PLAYER2: gonjWinPlayer1.SetActive(true); break;
        }
    }
}
