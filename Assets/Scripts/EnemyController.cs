using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float speed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float rateOfFire = 100.0f;
    public float stopDistance = 2.0f;

    Transform player;
    float timer = 0.0f;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate() {
        if(player) {
            var angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            rigidbody2D.angularVelocity = 0;

            if((player.position - transform.position).magnitude > stopDistance)
                rigidbody2D.AddForce(transform.up*speed);
            else {
                if (bulletPrefab && bulletSpawnPoint && timer <= 0.0f) {
                    var bullets = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation) as GameObject;
                    timer = 60.0f / rateOfFire;
                    foreach (Transform bullet in bullets.transform) {
                        if (bullet.collider2D) {
                            Physics2D.IgnoreCollision(collider2D, bullet.collider2D);
                        }
                    }

                    audio.Play();
                }
            }
        }
    }

    void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0)
            timer = 0;
    }
}
