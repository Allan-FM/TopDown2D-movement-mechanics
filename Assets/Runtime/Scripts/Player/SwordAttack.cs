using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordAttack : MonoBehaviour
{
    private Vector2 rigthAttackOffSet;
    private Collider2D swordCollider;
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();    
        rigthAttackOffSet = transform.position;
    }
    public void AttackRigth()
    {
        print("Attack Rigth");
        swordCollider.enabled = true;

        transform.position = rigthAttackOffSet;
    }
    public void AttackLeft()
    {
        print("Attack Left");
        swordCollider.enabled = true;

        transform.position = new Vector2(rigthAttackOffSet.x * -1, rigthAttackOffSet.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }
}
