using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private SwordAttack swordAttack;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool canMove = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PlayerMotionAnimation()
    {

        if(player.MovementInput != Vector2.zero)
        {
            bool success = player.TryMove(player.MovementInput);
            if(!success)
            {
                success = player.TryMove(new Vector2(player.MovementInput.x, 0));
            }
            if(!success)
            {
                success = player.TryMove(new Vector2(0, player.MovementInput.y));
            }
            animator.SetBool(PlayerAnimationConstants.IsMoving, success);
        }
        else
        {
            animator.SetBool(PlayerAnimationConstants.IsMoving, false);
        }

    }
    public void FlipSpriteToMovement()
    {
        if(player.MovementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(player.MovementInput.x > 0)
        {
            spriteRenderer.flipX = false;   
        }

    }
    private void SwordAttack()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRigth();
        }
    }
    public void AnimationAttack()
    {
        animator.SetTrigger(PlayerAnimationConstants.SwordAttack);
    }
    private void LockMovement()
    {
        canMove = false;
    }
}


