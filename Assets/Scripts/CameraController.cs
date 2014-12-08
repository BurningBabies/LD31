using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    GameController gc;
    GlitchEffect glitch;

    void Start() {
        gc = GameController.Get();
        glitch = GetComponent<GlitchEffect>();
    }

    void Update() {
        glitch.enabled = gc.rule == Rule.Glitch;
    }
}
