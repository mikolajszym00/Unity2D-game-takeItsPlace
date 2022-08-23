using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCollision : MonoBehaviour
{
    Vector2 movementDirection;
    float moveSpeed;

    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        moveSpeed = GetComponent<HeroMovement>().GetMoveSpeed();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "BaredTile") 
        {
            movementDirection = GetComponent<HeroMovement>().GetMovementDirection();


            
            // rb.velocity = -2*moveSpeed * movementDirection;
            // Vector3 delta = moveSpeed * movementDirection * Time.deltaTime;
            // transform.position -= 2 * delta;
        }
    }

}
