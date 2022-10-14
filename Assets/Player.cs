using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D RB;
    public Vector2 MovementInput;
    void Start()
    {
        
    }

    void Update()
    {
        MovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        RB.velocity = MovementInput;
    }

    private void FixedUpdate()
    {
        
    }
}
