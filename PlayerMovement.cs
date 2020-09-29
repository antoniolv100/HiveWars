using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public Animator playerAnim;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool Moving = false;

    // Update is called once per frame
    void Update () {

        horizontalMove = joystick.Horizontal * runSpeed;
        Anim ();
    }

    public void Jump(){
        jump = true;
    }

    void FixedUpdate () {
        // Move our character
        controller.Move (horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void Anim () {
        if (controller.velocity.x > 3) {
            Moving = true;
            playerAnim.SetBool ("Moving", true);
        } else if (controller.velocity.x < -3) {
            Moving = true;
            playerAnim.SetBool ("Moving", true);
        } else {
            Moving = false;
            playerAnim.SetBool ("Moving", false);
        }
    }
}

