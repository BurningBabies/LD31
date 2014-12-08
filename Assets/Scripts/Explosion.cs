using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float liveTime;

    void Awake() {
        Invoke("Die", liveTime);
    }

    void Die() {
        Destroy(gameObject);
    }
}
