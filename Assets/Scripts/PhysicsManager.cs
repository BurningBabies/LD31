using UnityEngine;
using System.Collections;

public class PhysicsManager : MonoBehaviour {
    public LayerMask bulletLayer;
    public LayerMask enemyLayer;

    void FixedUpdate() {
        Physics2D.IgnoreLayerCollision(1 >> bulletLayer.value, 1 >> bulletLayer.value, true);
        Physics2D.IgnoreLayerCollision(1 >> enemyLayer.value,  1 >> enemyLayer.value, true);
    }
}
