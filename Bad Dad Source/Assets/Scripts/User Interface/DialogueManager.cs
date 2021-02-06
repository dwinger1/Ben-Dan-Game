using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Text continueButton;
    private DialogueObject dialogueObject;
    public GameObject responseButton;
    public GameObject userInterfaceCanvas;

    private Queue<string> sentences; // change this to an array

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueObject dialogue) // Argument: pass in a dialogue to use
    {
        dialogueObject = dialogue;
        // Set the animator to the IsOpen state.
        animator.SetBool("IsOpen", true);

        // Set the NPC name to the DialogueManager's nameText. dialogue.name is coming from the serializable component of the DialogueTrigger.
        //nameText.text = dialogue.name;

        // Clear out any sentences from previous conversation from the Queue.
        sentences.Clear();

        // Load up each sentence into the queue.
        foreach (string sentence in dialogue.dialogue)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    // This method gets called by the continue button.
    {
        // Say goodbye when reaching the last sentence.
        if (sentences.Count == 1)
        {
            //TODO Hide the continue button
            HandleResponses();
        }
        // Close dialogue at the end of the sentences.
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

    private void HandleResponses()
    {
        int offSet = 0;
        foreach (DialogueResponse response in dialogueObject.responses)
        {
            CreateResponseButtons(response);
            offSet += 20;
            // Increment new button offset.
        }
    }

    private void CreateResponseButtons(DialogueResponse response)
    {
        GameObject newResponseButton = Instantiate(responseButton) as GameObject;
        newResponseButton.transform.SetParent(userInterfaceCanvas.transform, false);
        Debug.Log("Created new response button " + newResponseButton.transform);
        newResponseButton.GetComponentInChildren<Text>().text = response.responseText; // Set the text for the newly created response button.
        
    }
        // Create a new button for each response text item in the array.
        // Set the button text to the responseText.
        // Upon pressing the button, set the DialogueObject for this script to the linked response DialogueObject.
 

    // Sentence typing animation.
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        // Take the next letter in the sentence and append it to the text component.
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    // End dialogue
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}
