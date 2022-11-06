using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection
    {
        left, right
    }// end of enum 

    public float knockbackForce = 5000f;
    public static SwordAttack instnace;
    AttackDirection attackDirection;
    public float damage = 3;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;
    Animator animator;
    private void Start()
    {
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword Collider is not set.");
        }
        rightAttackOffset = transform.localPosition;
    }
    private void Update()
    {
        //rightAttackOffset = transform.localPosition;
    }

    /*
     * A method that chose between to case for the player based on which side its facing. 
     
    public void Attack()
    {
        switch (attackDirection)
        {
            case AttackDirection.left: // when facing left side call AttackLeftSide and switch hitbox location
                AttackLeftSide();
                break;
            case AttackDirection.right: // when facing rightside call AttackRightSide and enable hitbox location for right side.
                AttackRightSide();
                break;
        }
    }// end of Attack
    */
    public void AttackRightSide()
    {
        //Debug.Log("Attack Right Side");
        swordCollider.enabled = true; // enable the collider for sword hit box for player
        transform.localPosition = rightAttackOffset; // normal hitbox location when player facing right side as defualt.
    }// end of AttackRightSide


    public void AttackLeftSide()
    {
        //Debug.Log("Attack Left Side");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y); // reverse the hitbox for the sowrd to the left side.

    }// end of AttackLeftSide

    public void StopAttack()
    {
        swordCollider.enabled = false; // disable attack hitbox

    }// end of StopAttack

    //private void OnTriggerEnter2D(Collider2D collision)
    // {
    /*
    if(collision.tag == "Enemy")
    {
        // deal dmg
        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.OnHit(damage);
            Debug.Log("Damage Taken" + " Health is: " + enemy.Health);
        }
    }// end of if(collison) statement
    */
    //} // end of OnTriggerEnter2D
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        IDamageable damageableObject =  collision.GetComponent<IDamageable>();
        Debug.Log("Collision Entered");
        if (damageableObject != null)
        {
            // calcualte the direction between player and enemy
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

            Vector2 direction = (Vector2)(parentPosition - collision.gameObject.transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;

           // collision.collider.SendMessage("OnHit", damage, knockback); // check for an enemy physics rigidbody and sends on hit damage to the GameObject
            damageableObject.OnHit(damage, knockback); //
        }
        else
        {
            Debug.LogWarning("Collider does not implemet IDamageable interface");
        }
    }
    */
     void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableObject = collision.GetComponent<IDamageable>();
        
        if (damageableObject != null)
        {
            Debug.Log("Collision Entered");
            // calcualte the direction between player and enemy
            //Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (Vector2)(collision.gameObject.transform.position - parentPosition).normalized; // Offset for collision detection, changes the direction where the force comes from ( close to player)
            Vector2 knockback = direction * knockbackForce;// knockback is in direction of swordCollider twoards collider

            // collision.collider.SendMessage("OnHit", damage, knockback); // check for an enemy physics rigidbody and sends on hit damage to the GameObject
            damageableObject.OnHit(damage, knockback); //
        }
        else
        {
            Debug.LogWarning("Collider does not implemet IDamageable interface");
        }
    }
}

 
