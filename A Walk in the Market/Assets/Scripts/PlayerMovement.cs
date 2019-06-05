using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public Animator dialogueAnimator;
    public Animator playerMovementAnimator;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    private bool stopAnimation = false;

    private void Start()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex + 1;
        playerMovementAnimator.SetInteger("SceneNum", sceneNum - 1);
    }

    // Update is called once per frame
    //Use this to get input from user
    void Update () {

        //value between negative 1 and 1 that changes based on user input
        //left arrow or a = -1 and right arrow or d = 1
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //checks if the animation needs to be played or not
        if (stopAnimation == false)
        {
            playerMovementAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            playerMovementAnimator.SetFloat("Speed", 0);
        }
    }

    //used fixed update to apply player input
    void FixedUpdate()
    {
        //This actually moves the characters
        if (dialogueAnimator.GetBool("IsOpen") == false)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
            stopAnimation = false;
        }
        else
        {
            stopAnimation = true;
            controller.Move(0, false, false);
        }
    }

    public bool getStopAnimation() {
        return stopAnimation;
    }

    public void setStopAnimation(bool animation) {
        stopAnimation = animation;
    }
}
