using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text waveText;

    ScoreController sc;

    void Awake() {
        sc = ScoreController.Get();
        scoreText.text += sc.score.ToString("0");
        waveText.text += sc.wave;
        Destroy(sc.gameObject);
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            Application.LoadLevel("Gameplay");
        }
    }
}
