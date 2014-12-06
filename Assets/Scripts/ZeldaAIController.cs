using UnityEngine;
using System.Collections;

public class ZeldaAIController : MonoBehaviour {
    public Facing facing = Facing.Right;
    public float movementSpeed;

    void FixedUpdate() {
        rigidbody2D.velocity = GetFacingDirection()*movementSpeed*Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "TurnPoint") {
            if((transform.position - other.transform.position).sqrMagnitude < 0.005) {
                TurnPoint tp = other.GetComponent<TurnPoint>();

                do {
                    facing = (Facing)Random.Range(0, 4);
                    if((facing == Facing.Left && tp.canGoLeft) ||
                       (facing == Facing.Right && tp.canGoRight) ||
                       (facing == Facing.Up && tp.canGoUp) ||
                       (facing == Facing.Down && tp.canGoDown))
                        break;
                } while(true);
            }
        }
    }

    Vector2 GetFacingDirection() {
        switch (facing) {
            case Facing.Down:
                return new Vector2(0, -1);
            case Facing.Left:
                return new Vector2(-1, 0);
            case Facing.Right:
                return new Vector2(1, 0);
            case Facing.Up:
                return new Vector2(0, 1);
            default: 
                return Vector2.zero;
        }
    }
}
