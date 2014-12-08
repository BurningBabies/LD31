using UnityEngine;
using System.Collections;

public class BulletParent : MonoBehaviour {
    public float destroyTime = 10.0f;

    void Start() {
        Invoke("DestroyThis", destroyTime);
    }

    void DestroyThis() {
        Destroy(gameObject);
    }
}
