using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Vector2 movementDirection;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    bool heroHasHorizontalSpeed;

    void Start()
    {

    }

    void Update()
    {
        heroHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        Move();
        FilpSprite();
    }

    void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
    }

    void Move() 
    {
        rb.velocity = moveSpeed * movementDirection;

        bool heroHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        anim.SetBool("isRunning", heroHasHorizontalSpeed || heroHasVerticalSpeed);

        if (heroHasVerticalSpeed || heroHasHorizontalSpeed)
        {
            anim.SetBool("isUsingHand", false); 
        }
        
    }

    void FilpSprite()
    {
        heroHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (heroHasHorizontalSpeed) 
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
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
