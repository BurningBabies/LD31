using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
    public UnityEngine.UI.Image fader;
    public float fadeDuration = 1.0f;

    public void FadeToClear() {
        StartCoroutine(ClearFader());
    }

    public void FadeToBlack() {
        StartCoroutine(BlackFader());
    }

    void Awake() {
        fader.color = Color.black;
        FadeToClear();
    }

    IEnumerator ClearFader() {
        float t = 0;

        while(fader.color.a > 0.01) {
            fader.color = Color.Lerp(fader.color, Color.clear, t);
            t += Time.deltaTime / fadeDuration;
            yield return new WaitForEndOfFrame();
        }
        fader.color = Color.clear;
    }

    IEnumerator BlackFader() {
        float t = 0;

        while (fader.color.a < 1) {
            fader.color = Color.Lerp(fader.color, Color.black, t);
            t += Time.deltaTime / fadeDuration;
            yield return new WaitForEndOfFrame();
        }
        fader.color = Color.black;

        Application.LoadLevel("Score");
    }
}
