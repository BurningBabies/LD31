using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
    public float score;
    public int wave;

    void Awake() {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public static ScoreController Get() {
        return GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
    }
}
