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

    [SerializeField] float energyCost = 0.003f;
    [SerializeField] float atackEnergyCost = 10f;

    [SerializeField] GameObject slider;
    SliderControler energy;

    bool heroHasHorizontalSpeed;
    bool heroHasVerticalSpeed;

    void Start()
    {
        energy = slider.GetComponent<EnergySliderController>();
    }

    void Update()
    {
        Move();
        FilpSprite();
        AnimationHandler();
        AtackEnergyCost();
    }

    void OnMove(InputValue value)
    {
        movementDirection = value.Get<Vector2>();

        RunningEnergyCost();
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

    void AtackEnergyCost()
    {
        if (anim.GetBool("isAtacking"))
        {
            energy.DecreaseValue(energyCost * atackEnergyCost);
        }
    }

    void RunningEnergyCost() // bieganie i atak równoczeniśnie mogą zabierać więcej energii (**)
    {
        energy.DecreaseValue(energyCost);
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
