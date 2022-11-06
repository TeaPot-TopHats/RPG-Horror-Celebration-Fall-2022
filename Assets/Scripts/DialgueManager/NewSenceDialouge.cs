using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSenceDialouge : MonoBehaviour
{
    public Dialogue dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        // DialogueManager.instance.StartDialogue(dialogue);
      

       FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
       // FindObjectOfType<PauseMenu>().DialoguePause();
    }
 


}
