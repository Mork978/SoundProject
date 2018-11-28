using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Cada jugador tendrá su propio Timer.
 * Cosas a pensar:
 *      - Se acumula el tiempo sobrante?
 *      - Hay penalización si llega a 0?
 * 
 */

public class TimerController : MonoBehaviour {

    #region Unity References
    private Text txtTime;
    #endregion

    #region Variables
    public bool bStartTimer;
    private float fCurrentTime = 0;
    //private float fEndTime = 0;
    public bool bFinnish;
    #endregion

    #region Methods MonoBehaviour
    void Start () {
        GameController.Instance.scptActiveTimer = this;
        txtTime = gameObject.GetComponent<Text>();
        Init(GamesController.GetTimerActivePlayer(GamesController.GetPlayer()));


        //Init(GamesController.GetTimerActivePlayer(GamesController.GetPlayer()) + GamesController.GetTimeRound());
    }

    void Update () {
        CheckTime();
        if (bFinnish)  GamesController.SetTimerActivePlayer(GamesController.GetPlayer(), fCurrentTime);
    }
    #endregion

    #region Methods
    //Función para inicializar el timer
    private void Init(float _fInitTime) {
        fCurrentTime = _fInitTime;
        //fEndTime = 0;
        bFinnish = false;
        txtTime.text = fCurrentTime.ToString();
        bStartTimer = false;
    }

    //Función para actualizar el timer
    private void CheckTime() {
        if (!bFinnish && bStartTimer) {
            fCurrentTime -= Time.deltaTime;
            if (fCurrentTime < 0) {
                fCurrentTime = 0.0f;
                bFinnish = true;
                GameController.Instance.bGameFinnish = true;
                GameController.Instance.bGamePaused = true;
            }
            txtTime.text = fCurrentTime.ToString("0.00");
        }
    }

    //Función para iniciar el timer.
    public void ActiveTimer() {
        bStartTimer = true;
    }
    public void DeactiveTimer()
    {
        bFinnish = true;
    }
    #endregion
}
