using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public Rigidbody2D PlayerRB;
    public Vector2 movementInput;

    void FixedUpdate()
    {
        PlayerRB.MovePosition(PlayerRB.position + movementInput * playerSpeed * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }
}
