using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Dialogue State")]
public class DialogueStates : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string dialogueText; // The editor's textbox input in the inspector.
    [SerializeField] DialogueStates[] nextState; // State machine states list
    
    // Enable access to this object's text.
    public string GetText()
    {
        return dialogueText;
    }

    // Enable access to this object's next state
    public DialogueStates[] GetNextState()
    {
        return nextState;
    }
}
