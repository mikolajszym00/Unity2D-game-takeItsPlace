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
    [SerializeField] HeroVitality vitality;

    bool heroHasHorizontalSpeed;
    bool heroHasVerticalSpeed;

    void Update()
    {
        Move();
        FilpSprite();
        AnimationHandler();
        vitality.AttackEnergyCost(anim.GetBool("isAtacking"));
    }

    void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();

        vitality.RunningEnergyCost();
    }

    void Move() 
    {
        rb.velocity = moveSpeed * movementDirection;
    }

    void FilpSprite()
    {
        heroHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (heroHasHorizontalSpeed) 
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void AnimationHandler()
    {
        heroHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        heroHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;

        bool isRunning = (heroHasHorizontalSpeed || heroHasVerticalSpeed) && (!anim.GetBool("isAtacking"));
        anim.SetBool("isRunning", isRunning);
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
