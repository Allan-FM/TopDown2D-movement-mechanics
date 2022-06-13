using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
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
}


