using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float speed = 1f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private float collisionOffSet = 0.05f;
    private PlayerAnimationController playerAnimationController;
    private List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    private Rigidbody2D rb;
    public Vector2 MovementInput {get; private set;}
    private Vector2 movementInput => MovementInput;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }
    private void FixedUpdate()
    {
        playerAnimationController.PlayerMotionAnimation();
        playerAnimationController.FlipSpriteToMovement();
    }
    public bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            int count = rb.Cast(direction, movementFilter, 
                    castCollision, speed * Time.deltaTime + collisionOffSet);
            if(count == 0)
            {
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
            return false;
            }
        }
        else
        {
            return false;    
        }
    }
    private void OnMove(InputValue movementValue)
    {  
        MovementInput = movementValue.Get<Vector2>();
    }
    private void OnFire()
    {
        playerAnimationController.AnimationAttack();
    }
}

