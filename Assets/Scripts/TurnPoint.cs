using UnityEngine;
using System.Collections;

public class TurnPoint : MonoBehaviour {
    public bool canGoLeft;
    public bool canGoRight;
    public bool canGoUp;
    public bool canGoDown;
    public LayerMask walls;

    public float rayDistance = 0.55f;

    void Awake() {
        canGoLeft = !Physics2D.Raycast(transform.position, new Vector2(-1, 0), rayDistance, walls);
        canGoRight = !Physics2D.Raycast(transform.position, new Vector2(1, 0), rayDistance, walls);
        canGoUp = !Physics2D.Raycast(transform.position, new Vector2(0, 1), rayDistance, walls);
        canGoDown = !Physics2D.Raycast(transform.position, new Vector2(0, -1), rayDistance, walls);
    }
}
