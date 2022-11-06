using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool canMove = true;
    public float playerSpeed = 1f;
    public float collisionOffset = 0.05f;
    

    public Vector2 movementInput;
    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();    
    Rigidbody2D playerRB;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public SwordAttack swordAttack;
    private JSONSavingScript data;
    PlayerUICounter PlayerUI;


    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerUI = GetComponent<PlayerUICounter>();
    }   


    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero) // IF movement input is not 0, try to move
            {
                bool success = TryMove(movementInput); // nomral movement up/down/right/left and diagonally
                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0)); // if mormal movement fails, try only movement in X-axis direcetion
                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y)); // if normal  and x-axis movement fails, try only movement in Y-axis direction
                    }
                }
                animator.SetBool("IsMoving", success);
            }// end of if statment
            else
            {
                animator.SetBool("IsMoving", false);
            }
            // Set the dircetion of the sprite to the player movement direction 
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true; // if movement of x-axis is less than 0 flip the x-axis sprite / flip it to the left
                //swordAttack.attackDirection = SwordAttack.AttackDirection.left; // when facing left side set attack direction/hitbox for weapon to left side
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false; // if there is not input for x-axis movement leave the sprite as is/ flip it to the right
               // swordAttack.attackDirection = SwordAttack.AttackDirection.right; // when facing right side set attack/ hitbox for weaopn to right side
            }
        }// end of if(canMove)
    }// end of FixedUpdate
    /*
     * A method that check for potenial collision
     */

    public void SpawnPlayer()
    {
       
    }
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero) // stop movement/animation if colieded with an object
        {

            int count = playerRB.Cast(
                    direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collision
                    movementFilter, // the settings that detemine where a collision can occur on, such as layers to collide with
                    castCollisions, // List of collisions to store the found collisions into. After the cast is finished
                    playerSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset
            if (count == 0)
            {
                playerRB.MovePosition(playerRB.position + direction * playerSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }// end of second if-else

        } else {
            return false;
        }// end of of first if-else
    }// end of TryMove

    /*
     * A method to move the player using Unity new Input System by sending messages using OnMove call.
     * It assgin movement input of a keyboard to input value the input system knows and get the vector 2 axises direction.
     */
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }// end of OnMove
    
    /*
     * A method that uses the new Input system and send a messamge to Onfire and trigger an attack based on chosen keybind in the system.
     */
    void OnFire()
    {
          
        animator.SetTrigger("swordAttack");
        SwordAttack();
    }// end of OnFire

   

    /*
     *  A method that lock movement when attacking and check the which side the player sprite is facing and base on that change the hitbox location.
     */
    public void SwordAttack()
    {
        
        LockMovement();

        if(spriteRenderer.flipX == true) // check if the sprite flipped the x-axis, and if its true flip the hit box to left side
        {
            swordAttack.AttackLeftSide();
        }
        else
        {
            swordAttack.AttackRightSide(); // else use the right side defualt hitbox location.
        }
    } // end of SwordAttack

    /*
     * A method that disable hitbox after each swing and unlock movement
     */
    public void disableSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    /*
     * A method that lock movements
     */
    void LockMovement()
    {
        canMove = false;
    }// end of LockMovement
    
    /*
     * A method that enable movements
     */
    void UnlockMovement()
    {
        canMove = true;
    }

    public void PlaySwordSound()
    {
        AudioManager.instance.Play("sword");
    }

    public void PlayDeathSound()
    {
        AudioManager.instance.Play("playerDeath");
    }
}
