using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    public GameObject gobjTimer1;
    public GameObject gobjTimer2;
    public TimerController scrpTimer1;
    public TimerController scrpTimer2;
    public GameObject gobjRoundText;
    public GameObject gobjRoundCounter;
    public Text txtRoundCount;


    public bool bStart = false;
    public bool bPlayer1Played = false;
    public bool bPlayer2Played = false;
    public int iRoundCounter = 0;
    public bool bSelectPilar = false;



    // Update is called once per frame
    void Update () {

        //Inputs
        if (!bStart && Input.GetKeyUp(KeyCode.Space)) {
            bStart = true;
            if (!bPlayer1Played) ActiveTimer(scrpTimer1);
            if (!bPlayer2Played) ActiveTimer(scrpTimer2);
        }




        if (bStart) {
            if (!bPlayer1Played) UpdateTimer(scrpTimer1);
            if (!bPlayer2Played) UpdateTimer(scrpTimer2);
            if (bPlayer1Played && bPlayer2Played) NextRound();
        }
    }


    public void NextPlayer()
    {
        //Inicializamos jugador 2
        bStart = false;
        bSelectPilar = false;
    }
    public void NextRound() {
        iRoundCounter++;
        txtRoundCount.text = iRoundCounter.ToString();

        //Inicializamos jugador 1
        bStart = false;
        bSelectPilar = false;
    }
    
    public void ActiveTimer(TimerController _scrpTimer) {
        Debug.Log("Hola : " + _scrpTimer);
    }
    public void UpdateTimer(TimerController _scrpTimer) {
        
        //Si se acaba el tiempo de un jugador...
        if (_scrpTimer.bFinnish) {
            if (!bPlayer2Played && bPlayer1Played) bPlayer2Played = !bPlayer2Played;
            if (!bPlayer1Played)
            {
                bPlayer1Played = !bPlayer1Played;
                NextPlayer();
            }
            _scrpTimer.DeactiveTimer();
        }
        if (bSelectPilar)
        {
            _scrpTimer.DeactiveTimer();
        }
    }
}
