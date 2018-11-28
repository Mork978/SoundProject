using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GamesController {

    //General
    private static int iRoundCounter = 1;
    //private static float [] fLessTimerPerRound = { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60};
    private static float fTimePerRound = 20;
    public enum ePLAYER { PLAYER1 = 0, PLAYER2 = 1 }
    private static ePLAYER ePlayerActive;


    //Player 1
    private static float fTimerPayer1 = fTimePerRound;
    //private static float fScorePayer1 = 0.5f; //No es 0 para que la barra empieze ya mostrando valores.


    //Player 2
    private static float fTimerPayer2 = fTimePerRound;
    //private static float fScorePayer2 = 0.5f;


    //Gestión de Rondas
    public static void SetRoundCounter(int _iRoundConter) {
        iRoundCounter = _iRoundConter;
    }
    public static int GetRoundCounter() {
        return iRoundCounter;
    }
    /*public static float GetTimeRound() {
        float fReport = fTimePerRound;
        if (iRoundCounter <= 0) iRoundCounter = 1;
        if (iRoundCounter > 0 && iRoundCounter <= fLessTimerPerRound.Length) fReport -= fLessTimerPerRound[iRoundCounter - 1];
        if (iRoundCounter > fLessTimerPerRound.Length) fReport = 0;
        return fReport;
        
    }*/
    public static void NextRound() {
        if (ePlayerActive.Equals(ePLAYER.PLAYER2)) {
            ePlayerActive = ePLAYER.PLAYER1;
            iRoundCounter++;
        }else if (ePlayerActive.Equals(ePLAYER.PLAYER1)) ePlayerActive = ePLAYER.PLAYER2;
        
        SceneManager.LoadScene("RoundScene");
    }








    //Gestión de los Jugadores
    public static void SetPlayer(ePLAYER _ePlayerActive) {
        ePlayerActive = _ePlayerActive;
    }
    public static ePLAYER GetPlayer() {
        return ePlayerActive;
    }

    //Gestión de Timers
    public static float GetTimerActivePlayer(ePLAYER _ePlayerActive) {
        float fReport = 0;
        switch (_ePlayerActive) {
            case ePLAYER.PLAYER1: fReport = fTimerPayer1; break;
            case ePLAYER.PLAYER2: fReport = fTimerPayer2; break;
            default: Debug.LogError("Error. No has pasado el Player Activo. GetTimerActivePlayer()"); break;
        }
        return fReport;
    }

    public static float GetTimerDeactivePlayer(ePLAYER _ePlayerActive) {
        float fReport = 0;
        switch (_ePlayerActive) {
            case ePLAYER.PLAYER1: fReport = fTimerPayer2; break;
            case ePLAYER.PLAYER2: fReport = fTimerPayer1; break;
            default: Debug.LogError("Error. No has pasado el Player Activo. GetTimerDeactivePlayer()"); break;
        }
        return fReport;
    }
    public static void SetTimerActivePlayer(ePLAYER _ePlayerActive, float _fTimer) {
        switch (_ePlayerActive) {
            case ePLAYER.PLAYER1: fTimerPayer1 = _fTimer; break;
            case ePLAYER.PLAYER2: fTimerPayer2 = _fTimer; break;
            default: Debug.LogError("Error. No has pasado el Player Activo. SetTimerActivePlayer()"); break;
        }
    }

    //Gestión de Scores
    /*public static float GetScoreActivePlayer(ePLAYER _ePlayerActive) {
        float fReport = 0;
        switch (_ePlayerActive) {
            case ePLAYER.PLAYER1: fReport = fScorePayer1; break;
            case ePLAYER.PLAYER2: fReport = fScorePayer2; break;
            default: Debug.LogError("Error. No has pasado el Player Activo. GetScoreActivePlayer()"); break;
        }
        return fReport;
    }

    public static float GetScoreDeactivePlayer(ePLAYER _ePlayerActive) {
        float fReport = 0;
        switch (_ePlayerActive) {
            case ePLAYER.PLAYER1: fReport = fScorePayer2; break;
            case ePLAYER.PLAYER2: fReport = fScorePayer1; break;
            default: Debug.LogError("Error. No has pasado el Player Activo. GetTScoreDeactivePlayer()"); break;
        }
        return fReport;
    }

    public static void SetScoreActivePlayer(ePLAYER _ePlayerActive, float _fScore) {
        switch (_ePlayerActive) {
            case ePLAYER.PLAYER1: fScorePayer1 = _fScore; break;
            case ePLAYER.PLAYER2: fScorePayer2 = _fScore; break;
            default: Debug.LogError("Error. No has pasado el Player Activo. SetScoreActivePlayer()"); break;
        }
    }
    */
    public static void ShowStatus() {
        Debug.Log("ActivePlayer :: " + GetPlayer());
        Debug.Log("Round :: " + GetRoundCounter());
        //Debug.Log("Scores -> Score Active Player :: " + GetScoreActivePlayer(GetPlayer()) + " , Score Deactive Player :: " + GetScoreDeactivePlayer(GetPlayer()));
        Debug.Log("Timers -> Timer Active Player :: " + GetTimerActivePlayer(GetPlayer()) + " , Timer Deactive Player :: " + GetTimerDeactivePlayer(GetPlayer()));
    }

    
}
