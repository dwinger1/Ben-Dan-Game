﻿using System;
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
    private string goodbye;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) // Argument: pass in a dialogue to use
    {
        // Set the animator to the IsOpen state.
        animator.SetBool("IsOpen", true);

        // Change the name of the dialogue name component.
        nameText.text = dialogue.name;

        // Clear out any sentences from previous conversation from the Queue.
        sentences.Clear();

        continueButton.text = "CONTINUE >>";
        //TODO clear the previous option buttons

        // Load up each sentence into the queue.
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        goodbye = dialogue.goodbye;
        DisplayNextSentence();
    }

    private void PickState()
    {
        throw new NotImplementedException();
    }

    public void DisplayNextSentence()
    // This method gets called by the continue button.
    //TODO Dialogue states: enable the option for the dialogue to have a 
    /* state from which to choose. Load in the state machine state and have that call a dialoge trigger.
     * Consider also using an if statement to check for which button gets pressed or have something on the dialogue sentence itself to branch off into options.
     * */
    {
        // Say goodbye when reaching the last sentence.
        if (sentences.Count == 1)
        {
            continueButton.text = goodbye;
        }
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

    // First option button
    public void Option1()
    {
        throw new NotImplementedException();
    }

    // Second option button
    public void Option2()
    {
        throw new NotImplementedException();
    }

    // End dialogue
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}