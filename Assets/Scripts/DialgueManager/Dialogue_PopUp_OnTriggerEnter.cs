using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_PopUp_OnTriggerEnter : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogueManager.instance.StartDialogue(dialogue);
        }
      //  DialogueManager.instance.StartDialogue(dialogue);
      //  Destroy(gameObject);
        //FindObjectOfType<AudioManager>().Play("dead3");
       // AudioManager.instance.Play("dead3");
    }
}
