using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float speed = 1f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private float collisionOffSet = 0.05f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool  success = TryMove(movementInput);
            if(!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                if(!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

            }
        }
    }
    private bool TryMove(Vector2 direction)
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
    private void OnMove(InputValue movementValue)
    {  
        movementInput = movementValue.Get<Vector2>();
    }
}

