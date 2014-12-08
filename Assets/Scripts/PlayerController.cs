using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
    public float speed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float rateOfFire = 666.0f;
    public float NoScopeRotatingSpeed;

    float timer = 0.0f;
    float leftBorder, topBorder, rightBorder, downBorder;
    GameController gc;

    void Awake() {
        gc = GameController.Get();

        var topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        var bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
        leftBorder = topLeft.x;
        topBorder = topLeft.y;
        rightBorder = bottomRight.x;
        downBorder = bottomRight.y;
    }

    void FixedUpdate() {
        if(gc.rule != Rule.NoScope360) {
            var lookDirection = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var rotation = Quaternion.LookRotation(lookDirection, Vector3.forward);
            transform.rotation = Quaternion.Euler(0, 0, rotation.eulerAngles.z);
            rigidbody2D.angularVelocity = 0;
        }
        else {
            rigidbody2D.angularVelocity = NoScopeRotatingSpeed;
        }

        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody2D.AddForce(input*speed);

        if(transform.position.x < leftBorder - 0.1f) 
            rigidbody2D.MovePosition(new Vector2(rightBorder, rigidbody2D.position.y));
        if (transform.position.x > rightBorder + 0.1f)
            rigidbody2D.MovePosition(new Vector2(leftBorder, rigidbody2D.position.y));
        if (transform.position.y > topBorder + 0.1f)
            rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x, downBorder));
        if (transform.position.y < downBorder - 0.1f)
            rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x, topBorder));
    }

    void Update() {
        if (Input.GetButton("Fire1") && gc.rule != Rule.CantShoot) {
            if (bulletPrefab && bulletSpawnPoint && timer <= 0.0f) {
                var bullets = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation) as GameObject;
                timer = 60.0f / rateOfFire;
                foreach(Transform bullet in bullets.transform) {
                    if(bullet.collider2D) {
                        Physics2D.IgnoreCollision(collider2D, bullet.collider2D);
                    }
                }

                audio.Play();
            }
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
            timer = 0;
    }
}
