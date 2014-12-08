using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Jump"))
            Application.LoadLevel("Gameplay");
    }
}
