using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    /*
     * 
     * Clase para gestionar la Progress Bar.
     * 
     */

    //Para acceder a la clase -> GameController.Instance.scrScore.()

    #region Unity References
    //Barra de progreso
    #endregion


    #region Variables
    public float fScorePaleyer1;
    public float fScorePaleyer2;
    public float fPercentScoreBar;
    #endregion


    #region Methods MonoBehaviour
    // Use this for initialization
    void Start () {
        Init();
    }
    #endregion

    #region Methods
    //Función para actualizar la barra de progreso.
    public void UpdateProgressBar() {
        float fTotalScore = fScorePaleyer1 + fScorePaleyer1; //Valor del 100% de la ProgressBar.
        fPercentScoreBar = (fScorePaleyer1 * 100.0f) / fTotalScore; //Valor % de la score1. La Score2 es el resto.
        //Setear valores al ProgressBar.
    }
    /*
    //Función para pasar puntuacion
    public void SetScore(float _fScore, GameController.eTurnStates _eTurn) {
        switch (_eTurn) {
            case GameController.eTurnStates.TURN_PLAYER1:
                fScorePaleyer1 += _fScore;
                break;
            case GameController.eTurnStates.TURN_PLAYER2:
                fScorePaleyer2 += _fScore;
                break;
        }
    }
    */
    //Función para inicializar la Barra de puntuaciones.
    private void Init() {
        //No empiezan en 0, para que no haya un problema de visualización de la barra.
        fScorePaleyer1 = 0.5f;
        fScorePaleyer2 = 0.5f;
        UpdateProgressBar();
    }
    #endregion
}
