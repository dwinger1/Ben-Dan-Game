using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will sit on the NPC or character that is starting a new dialogue with the player.
/// </summary>
public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] public DialogueObject dialogue; // We will be using the serializable attributes from the DialogueObject script.

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

