using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public GameObject deathMenuUI;
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    JSONSavingScript data;
    PlayerUICounter playerUI;
    PauseMenu pause;

    
    public bool _tragetable = true;
    public float Health
    {
        set
        {
            data.myplayer.health = value;
            if (data.myplayer.health <= 0)
            {
                Defeated();
                Tragetable = false;
            }
        }
        get
        {
            return data.myplayer.health;
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
          //  physicsCollider.enabled = value;
            rb.simulated = value;
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
        data = GetComponent<JSONSavingScript>();
       
    }

    public void Defeated()
    {
        //CheckIsAlive();
        animator.SetTrigger("Defeated");
        deathMenuUI.SetActive(true);
    }// end of Defeated

    public void CheckIsAlive()
    {
        if(Health <= 0)
        {
            playerUI.enabled = false;
            Tragetable = false;
        }
    }


    public void DestroyPlayerObject()
    {
        Destroy(gameObject);
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(float damage)
    {
        AudioManager.instance.Play("playerHit");
        Health -= damage;
        Debug.Log("Player hit for: " + damage);
        Debug.Log("Player health is: " + Health);
    }

    
}
