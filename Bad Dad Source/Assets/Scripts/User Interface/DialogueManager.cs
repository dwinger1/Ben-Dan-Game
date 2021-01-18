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

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) // pass in a dialogue to use
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        // Clear out any sentences from previous conversation from the Queue.
        sentences.Clear();

        // Load up each sentence into the queue.
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    // This method gets called by the continue button.
    //TODO Dialogue states: enable the option for the dialogue to have a 
    /* state from which to choose. Load in the state machine state and have that call a dialoge trigger.
     * Consider also using an if statement to check for which button gets pressed or have something on the dialogue sentence itself to branch off into options.
     * */
    {
        if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
        // Remove the next sentence from the queue or "dequeue"
        string sentence = sentences.Dequeue();
        // Stop any current coroutines in case the  player goes to the next sentence before the previous one finished animating.
        StopAllCoroutines();
        // Output the sentence into dialogeText
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
        {
            animator.SetBool("IsOpen", false);
            Debug.Log("End of conversation");
        }
}
