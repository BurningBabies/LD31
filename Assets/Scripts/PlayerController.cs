using UnityEngine;
using System.Collections;

public enum Facing {
    Up, 
    Down,
    Left, 
    Right
}

public class PlayerController : MonoBehaviour {
    public float movementSpeed;
    public Facing facing = Facing.Down;
    public float coolDownTime;

    Animator anim;
    Transform sword;

    void Awake() {
        anim = GetComponent<Animator>();
        StartCoroutine(Attack());

        sword = transform.FindChild("Sword").transform;
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigidbody2D.velocity = new Vector2(h, v).normalized * movementSpeed * Time.deltaTime;

        UpdateFacing(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void UpdateFacing(float h, float v) {
        if(h == 0 && v == 0) return;

        if (v > 0)
            facing = Facing.Up;
        else if(v < 0)
            facing = Facing.Down;
        else
            facing = (h >= 0) ? Facing.Right : Facing.Left;
    }

    IEnumerator Attack() {
        for(;;) {
            if(Input.GetButton("Fire1")) {
                anim.SetTrigger("Attack");
                float swordAngle = 0;
                switch(facing) {
                    case Facing.Down:
                        swordAngle = 0;
                        break;
                    case Facing.Left:
                        swordAngle = 270;
                        break;
                    case Facing.Right:
                        swordAngle = 90;
                        break;
                    case Facing.Up:
                        swordAngle = 180;
                        break;
                }

                sword.rotation = Quaternion.Euler(0, 0, swordAngle);

                yield return new WaitForSeconds(coolDownTime);
            }

            yield return null;
        }
    }

    void DoAttackHit() {

    }
}
