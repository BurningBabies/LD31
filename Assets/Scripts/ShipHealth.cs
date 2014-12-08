using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {
    public float health;
    public float maxHealth;
    public UnityEngine.UI.Text healthText;
    public float killScore = 10;
    public float healthDropChance = 0.15f;
    public GameObject healthDrop;
    public GameObject explosion;

    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        UpdateText();
    }

    void Die() {
        if (transform.tag == "Player")
            GameController.Get().Fail();
        else if(transform.tag == "Enemy") {
            ScoreController.Get().score += killScore;
            if(Random.Range(0.0f, 1.0f) <= healthDropChance && healthDrop)
                Instantiate(healthDrop, transform.position, Quaternion.identity);
        }

        if(explosion) {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void TakeDamage(float damage) {
        anim.SetTrigger("Hit");

        health -= damage;
        if(health <= 0) {
            health = 0;
            Die();
        }
        UpdateText();
    }

    public void UpdateText() {
        if (healthText) {
            healthText.text = "HEALTH: " + health.ToString() + "/" + maxHealth.ToString();
        }
    }
}
