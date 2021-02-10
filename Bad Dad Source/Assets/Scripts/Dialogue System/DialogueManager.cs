using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText; // This holds the name of the NPC the dialogue is coming from.
    public Text dialogueText;
    public Animator animator;
    public Text continueButton;
    private DialogueObject dialogueObject; // This is used to set what dialogue manager is currently using for displaying dialogue.
    public GameObject responseButton;
    public GameObject dialogueBox; // This is the dialogue box GUI container that holds the location of all the dialogue GUI components...
                                     // We use it in this script to move response button positions.
    [SerializeField] private int offSet = 0; // This is used to move each new response button so that they don't display overtop each other.

    private Queue<string> sentences; // change this to an array

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueObject dialogue, string dialogueTriggerName) // Argument: pass in a dialogue to use
    {
        dialogueObject = dialogue;
        
        // Set the animator to the IsOpen state.
        animator.SetBool("IsOpen", true);

        // Set the NPC name to the DialogueManager's nameText. dialogue.name is coming from the serializable component of the DialogueTrigger.
        nameText.text = dialogueTriggerName;

        HandleSentences(dialogue);
    }

    private void HandleSentences(DialogueObject dialogue) //TODO Use this as an OnClick event in the responses?
    {
        // Clear out any sentences from previous conversation from the Queue.
        sentences.Clear();

        // Load up each sentence into the queue.
        foreach (string sentence in dialogue.dialogue)
        {
            sentences.Enqueue(sentence);
        }
        
        // Show the next sentence.
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    // This method gets called by the continue button.
    {
        // Show response options when reaching the last sentence.
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
        offSet = 0; // Initialize offSet to 0.
        foreach (DialogueResponse response in dialogueObject.responses)
        {
            CreateResponseButtons(response, offSet);
            offSet -= 25; // Increment new button offset.
        }
    }

    private void CreateResponseButtons(DialogueResponse response, int offSet)
    {
        RectTransform buttonPos; // This stores the position on the screen that the newly created button will be located.
        GameObject newResponseButton; // This is a new instantiation of the response button prefab.
        Button button; // This is going to be used to add a listener to this response button.
        
        //Create a button...
        newResponseButton = Instantiate(responseButton) as GameObject;

        // Set the new button as a child of the dialogue box.
        newResponseButton.transform.SetParent(dialogueBox.transform, false);

        // Get the RectTransform (button position on canvas) of the newly created response button.
        buttonPos = newResponseButton.GetComponent<RectTransform>();
        // Move each new response button down by the offset amount so you can see it.
        buttonPos.localPosition += new Vector3(0,offSet,0); 

        Debug.Log("Created new response button " + newResponseButton.transform);

        // Set button text.
        newResponseButton.GetComponentInChildren<Text>().text = response.responseText;

        // Change button's onclick event to change which dialogue object the dialogue manager is using.
        //newResponseButton.GetComponent<ResponseButton>().newDialogue = response.dialogueObject;
        button = newResponseButton.GetComponent<Button>();
        button.onClick.AddListener(() => HandleSentences(response.dialogueObject));
    }

    //public void ResponseButtonFunction(DialogueObject dialogue)
    //{
    //    dialogueObject = dialogue;
    //    HandleSentences(dialogueObject); // Recall HandleSentences using the new dialogue that is linked to the selected response.
    //}
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
