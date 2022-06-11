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
            int count = rb.Cast(movementInput, movementFilter, 
                castCollision, speed * Time.deltaTime + collisionOffSet);
            if(count == 0)
            {
                rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
            }
        }
    }
    private void OnMove(InputValue movementValue)
    {  
        movementInput = movementValue.Get<Vector2>();
    }
}

