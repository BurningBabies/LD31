using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    public float speed;
    public string targetTag;
    public float damage;

    GameController gc;

    void Start() {
        gc = GameController.Get();
    }

    void FixedUpdate() {
        rigidbody2D.AddForce(transform.rotation * Vector2.up * speed);
    }

    void OnCollisionEnter2D(Collision2D col) {
        foreach(var contact in col.contacts) {
            if(contact.collider.tag == targetTag) {
                if (gc.rule == Rule.OneShot)
                    contact.collider.SendMessage("TakeDamage", 100, SendMessageOptions.DontRequireReceiver); 
                else if (gc.rule != Rule.DoubleDamage)
                    contact.collider.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver); 
                else
                    contact.collider.SendMessage("TakeDamage", damage * 2, SendMessageOptions.DontRequireReceiver); 
            }
        }

        DestroyThis();
    }

    void DestroyThis() {
        Destroy(gameObject);
    }
}
