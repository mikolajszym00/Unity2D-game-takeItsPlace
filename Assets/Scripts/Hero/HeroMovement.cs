using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Vector2 movementDirection;

    [SerializeField] Rigidbody2D rb;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
    }

    void Move() 
    {
        // rb.velocity = moveSpeed * movementDirection;
        Vector3 delta = moveSpeed * movementDirection * Time.deltaTime;
        transform.position += delta;
    }

    public Vector2 GetMovementDirection()
    {
        return movementDirection;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

}
