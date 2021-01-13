using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Dialogue State")]
public class DialogueStates : ScriptableObject
{
    //TODO create bool for pausing game in the background when dialogue prompts
    //TODO create a bool for game over trigger
    //TODO create methods to enable manipulation of player stats through dialogue options (e.g. player earns money from interaction)


    [TextArea(10, 14)] [SerializeField] string dialogueText; // The editor's textbox input in the inspector.
    [SerializeField] DialogueStates[] nextState; // State machine states list
    [SerializeField] bool willPauseGame = true;
    
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

    private void Pause()
    {
        if (willPauseGame)
        {

            /*https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
             * */
        }
    }
}
