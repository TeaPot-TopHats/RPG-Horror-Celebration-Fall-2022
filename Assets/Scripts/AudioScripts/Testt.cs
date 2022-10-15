using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testt : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "player")
        {
            FindObjectOfType<AudioManager>().Play("dead3");
        }
    }
}
