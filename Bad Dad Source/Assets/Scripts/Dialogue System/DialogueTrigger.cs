using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will sit on the NPC or character that is starting a new dialogue with the player.
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [Header("What dialogue should we start with?")]
    [SerializeField] public DialogueObject dialogue; // We will be using the serializable attributes from the DialogueObject script.
    [Header("What should we call this NPC?")]
    [SerializeField] public string dialogueTriggerName; // The name of the NPC or object that is starting the dialogue.

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueTriggerName);
    }
}

