using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    public string name;
    [Tooltip("What the user will see as a reply before closing the dialogue box.")]
    

    [TextArea(3, 10)]
    public string[] sentences; // NPC dialogue text.

    [TextArea(3, 10)]
    public string[] responses; // Player responses.

    public string goodbye;

    public DialogueTrigger[] dialogeStates;

}
