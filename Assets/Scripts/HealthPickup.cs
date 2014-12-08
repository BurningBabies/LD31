using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
    public float healthRestored = 10.0f;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            audio.PlayOneShot(audio.clip);
            Destroy(gameObject);
            ShipHealth sh = other.GetComponent<ShipHealth>();
            sh.health = Mathf.Min(sh.health + healthRestored, sh.maxHealth);
            sh.UpdateText();
        }
    }
}
