using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    public string name;
    [Tooltip("What the user will see as a reply before closing the dialogue box.")]
    public string goodbye;

    [TextArea(3, 10)]
    public string[] sentences;

    public DialogueVirtualTrigger[] branchingDialogue;

    public bool triggerGameOver;

    
}
