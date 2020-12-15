using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script will be used to control changing scenes throughout the game. 
/// The current iteration uses scene indexes to reference scenes.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    int gameSceneIndex = 1; // Using this as a way to change what scene index is considered to be for the "Game" scene from the editor.

    // Load up the game scene.
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }
}
