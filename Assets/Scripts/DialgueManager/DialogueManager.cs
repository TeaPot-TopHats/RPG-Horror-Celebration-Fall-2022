using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance { get; private set; }

    private void Awake()
    {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
        dialogueText.text = string.Empty;
        sentences = new Queue<string>(); 
    }// end of start

    /*
     * A method that starts up the dialogue with an NPC. 
     * It set the text to name of chosen npc
     * It put all pre-written dialogue in a que 
     * Lasty it calls DisplayNextSentence
     */
    public void StartDialogue(Dialogue dialogue)
    {
        
       // PauseMenu.GameIsPaused = true;
       // PauseMenu.instance.UnlockMouseCursor();

        animator.SetBool("IsOpen", true);
        AudioManager.instance.Play("hover");
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
       // Debug.Log(sentences);
        Debug.Log("OH SHIT");
         sentences.Clear();
        Debug.Log("OH FUCK");

        foreach (string sentence in dialogue.sentences)
        {
            //Debug.Log(sentences);
            sentences.Enqueue(sentence);
           // Debug.Log(sentences);
        }
        
        DisplayNextSentence();
    }

    /*
     * A method that check if the sentence queue is empty or not.
     * If empty end the dialouge
     * Else
     * Start De-queuing the queue
     * It also stop all Co-routiens currently running if any and start a Co-rotuine for our sentence 
     */
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
         string sentence = sentences.Dequeue();
         StopAllCoroutines();
         StartCoroutine(TypeSentence(sentence));
         

         Debug.Log(sentence);
    }// end of Display next Sentence

    public void ClickToDisplyNextSentence()
    {
     
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisplayNextSentence();
        }
    }

    /*
     *  A method that goes through all our pre-written dialouge and parse the letter/character and type them one by one.
     *  The yeild return is for how fast it runs each foreach. ( how fast or slow it types each letter)
     */
    IEnumerator TypeSentence (string sentence)
    {
        float i = 0.01f;
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(i);
        }
    }

   void EndDialogue()
    {
      //  FindObjectOfType<PauseMenu>().LockMouseCursor();
        animator.SetBool("IsOpen", false);
        //PauseMenu.GameIsPaused = false;

        // Debug.Log("End Of Conversation");
    }
}
