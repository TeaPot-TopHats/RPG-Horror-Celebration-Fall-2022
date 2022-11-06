using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    Collider2D physicsCollider;
    Animator animator;

    public float damage = 1;
    public bool _tragetable = true;
    public float health = 1;
    public float Health 
    {
        set
        {
            health = value;
            
            if(health <= 0)
            {
                Defeated();
                Tragetable = false;
            }
        }
        get
        {
            return health;
        }    
    }// end of property Health

    public bool Tragetable 
    {
        get
        {
            return _tragetable;
        }
        set 
        { 
            _tragetable = value;
            physicsCollider.enabled = value;
            rb.simulated = value;
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }// end of Defeated

    public void DestroyEnemyObject()
    {
        Destroy(gameObject);
    }
    public void OnHit(float damage, Vector2 knockback) // An On hit method for enemy to receive hit and knockback
    {
        animator.SetTrigger("IsDamaged");
        Health -= damage;
        // apply force to enemy rigidbody
        rb.AddForce(knockback);
        Debug.Log("Force Applied: " + knockback);


        Debug.Log("Enemy hit for: " + damage);
        Debug.Log("Enemy health is: " + health);
    }
    public void  OnHit(float damage)  // An On hit method for enemy to receive only hit and with out knockback
    {
        animator.SetTrigger("IsDamaged");
        Health -= damage;
        Debug.Log("Enemy hit for: " + damage);
        Debug.Log("Enemy health is: " + health);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.OnHit(damage);
            //Debug.Log("Player got Hit for: " + damage);
        }
        
    }
    /*
  void OnHit(float damage)
 {
     animator.SetTrigger("IsDamaged");
     Health -= damage;  
     Debug.Log("Enemy hit for: " + damage);
     Debug.Log("Enemy health is: " + health);
 }// end of TakeDamage
 */

}
