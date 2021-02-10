using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue Object")]
[System.Serializable]
public class DialogueObject : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] dialogue;

    public DialogueResponse[] responses;
}
