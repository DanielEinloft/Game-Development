using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This is the basic template for the player movement. Using a Xbox controller, the player will be able to move the character with the joysticks,
    and dash and crouch using the corresponding buttons.

    Method descriptions:
    **UpdateButtons(): Method used to update the input strings if the player change the input buttons on GameControllerScript.
     */
public class MovementController : MonoBehaviour
{

    //string input buttons
    string crouchButton;
    string dashButton;
    string horizontal;
    string vertical;


    //Update the player input from parent
    void UpdateButtons()
    {
        GameControllerScript gameControllerScript = GameObject.FindObjectOfType<GameControllerScript>();
        crouchButton = gameControllerScript.crouchButton;
        dashButton = gameControllerScript.dashButton;
        horizontal = gameControllerScript.horizontal;
        vertical = gameControllerScript.vertical;
    }

    private void OnEnable()
    {
        UpdateButtons();
    }


    // Use this for initialization
    void Start ()
    {
        UpdateButtons();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
