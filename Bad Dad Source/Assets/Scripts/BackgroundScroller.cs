using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    float playerSpeed;
    Material myMaterial;
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        
    }

    // Get the speed the player is supposed to be moving at from the MoveCar script's inputs.
    private float SetPlayerSpeed()
    {
        // Utilize the player speed found in the MoveCar script. This keeps the inputs
        // all in one script.
        playerSpeed = FindObjectOfType<MoveCar>().GetPlayerSpeed();
        Debug.Log("Player speed: " + playerSpeed);
        return playerSpeed;
    }

    void MoveBackground()
    {
        // Call Set Player Speed method to find the player speed.
        SetPlayerSpeed();

        // Declare an "offset" that will be moving the texture, 
        // lock it horizontally and move it based on the player's speed.
        offSet = new Vector2(0f, playerSpeed);

        // Change the background quad's texture offset aka the background.
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }
}
