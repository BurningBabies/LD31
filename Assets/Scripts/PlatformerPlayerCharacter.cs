using UnityEngine;
using System.Collections;

public class PlatformerPlayerCharacter : MonoBehaviour {
    public float movementSpeed;
    public float jumpForce;

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
            rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
