using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This is the basic template for player animation. Through the player input, the character will change the animation corresponding the input commands.
    For example, if player walks slowly, the controller will set the 'Walk' animation. Currently this scrip controls: Walking Animation, Running Animation and Attacking Animation

    Methods descriptions:
        **UpdateButtons(): Method used to update the input strings if the player change the input buttons on GameControllerScript.
        **Controller(): Method used to control all the animations through the player's input.
       */
public class AnimationController : MonoBehaviour
{

    //string input buttons
    public string attackButton;
    public string crouchButton;
    public string dashButton;
    public string horizontal;
    public string vertical;


    //Components
    Animator animator;


    //
    Vector2 playerInput;

    //Update the player input from parent
    void UpdateButtons()
    {
        GameControllerScript gameControllerScript = GameObject.FindObjectOfType<GameControllerScript>();
        attackButton = gameControllerScript.attackButton;
        crouchButton = gameControllerScript.crouchButton;
        dashButton = gameControllerScript.dashButton;
        horizontal = gameControllerScript.horizontal;
        vertical = gameControllerScript.vertical;
    }

    private void Start()
    {
        if (animator == null)
            animator = gameObject.GetComponent<Animator>();
        UpdateButtons();


    }

    private void OnEnable()
    {
        UpdateButtons();
    }



    // Update is called once per frame
    void Update()
    {
        playerInput.x = Input.GetAxis(horizontal);
        playerInput.y = Input.GetAxis(vertical);
        Controller();
    }
    void Controller()
    {
            //control Idle, Walk and Run animation
            if (playerInput.magnitude > 0.1)
            {
                animator.SetBool("Moving", true);
                if (playerInput.magnitude > 0.5)
                    animator.SetBool("Run", true);
                else
                    animator.SetBool("Run", false);


                    animator.SetFloat("playerInputX", playerInput.x);
                    animator.SetFloat("playerInputY", playerInput.y);

                    //attack animation:
                    //check if the bigger input is on the vertical or horizontal axis
                    bool direction = Mathf.Abs(playerInput.x) > Mathf.Abs(playerInput.y);
                    if (direction)
                    {
                        //if we're on horizontal axis...left or right?
                        animator.SetFloat("YDirection", 0);
                        animator.SetFloat("XDirection", playerInput.x > 0 ? 1 : -1);
                    }
                    else
                    {
                        //if we're on vertical axis..up or down?
                        animator.SetFloat("YDirection", playerInput.y > 0 ? 1 : -1);
                        animator.SetFloat("XDirection", 0);
                    }
            }
            else
            {
                //if is not moving
                animator.SetBool("Moving", false);
                animator.SetBool("Run", false);
            }
            //if player press attack button
            if (Input.GetButtonDown(attackButton))
                animator.SetBool("Attacking", true);
            else
                animator.SetBool("Attacking", false);
    }




}
