using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    float playerSpeed;
    float backgroundSpeed;
    [SerializeField] float speedDividend = 1;
    Material myMaterial;
    Vector2 offSet;

    /*
     * Get player speed from MoveCar
     * Tune the number so that the background scroll speed is going at a different rate
     * 
     */

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

    private void SetBackgroundSpeed(float playerSpeed)
    {
        backgroundSpeed = playerSpeed / speedDividend;
        // Declare an "offset" that will be moving the texture, 
        // lock it horizontally and move it based on the player's speed.
        offSet = new Vector2(0f, backgroundSpeed);

        Debug.Log(" ps " + playerSpeed + " bgs " + backgroundSpeed);
    }

    private void MoveBackground()
    {
        SetBackgroundSpeed(SetPlayerSpeed());

        // Change the background quad's texture offset aka the background.
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }
}
