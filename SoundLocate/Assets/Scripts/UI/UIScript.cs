using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text txtScore1;
    public Text txtScore2;
    public Text txtExplanionScores;

    public void OnPressPlayButton() {
        //SceneManager.LoadScene("GameScene");
        //Dev 
        SceneManager.LoadScene("SampleScene");
    }

    public void OnPressMenuButton() {
        SceneManager.LoadScene("MenuScene");
    }

    private void Start() {
        if (SceneManager.GetActiveScene().name.Equals("FinnishScene")) ShowScores();
    }

    private void ShowScores() {
        /*txtScore1.text = GameController.Instance.scrScore.fScorePaleyer1.ToString();
        txtScore2.text = GameController.Instance.scrScore.fScorePaleyer2.ToString();
        txtExplanionScores.text = "lo que sea! aquí se dice que jugador ha ganado";*/
    }
}
