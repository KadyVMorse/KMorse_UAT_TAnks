﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will attach these codes to the objects that have this code 
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(TankData))]
public class TankMotor : MonoBehaviour
{
    //private variables that relate to the code only and defines them
    private CharacterController characterController;
    private Transform tf;
    private TankData data;


    // Start is called before the first frame update
    void Start()
    {
        //creats the character controller and what they are equal to
        characterController = gameObject.GetComponent<CharacterController>();
        tf = gameObject.GetComponent<Transform>();
        data = gameObject.GetComponent<TankData>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move(float speed)
    {
        // Create a vector to hold our speed data
        Vector3 speedVector = tf.forward * speed;

        // Start with the vector pointing the same direction as the GameObject this script is on.


        // Now, instead of our vector being 1 unit in length, apply our speed value

        // Call SimpleMove() and send it our vector
        // Note that SimpleMove() will apply Time.deltaTime, and convert to meters per second for us!
        characterController.SimpleMove(speedVector);
    }
    // Rotate: This function rotates our tank
    public void Rotate(float speed)
    {
        // Create a vector to hold our rotation data
        Vector3 rotateVector = Vector3.up * speed * Time.deltaTime;

        // Start by rotating right by one degree per frame draw. Left is just "negative right".


        // Now, rotate our tank by this value - we want to rotate in our local space (not in world space).
        tf.Rotate(rotateVector, Space.Self);
    }


    // RotateTowards (Target) - rotates towards the target (if possible).
    // If we rotate, then returns true. If we can't rotate (because we are already facing the target) return false.
    public bool RotateTowards(Vector3 target, float speed)
    {


        // The vector to our target is the DIFFERENCE between the target position and our position.
        //   How would our position need to be different to reach the target? "Difference" is subtraction!
       Vector3 vectorToTarget = target - tf.position;

        // Find the Quaternion that looks down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);

        // If that is the direction we are already looking, we don't need to turn!
        if (targetRotation == tf.rotation)
        {
            return false;
        }

        // Otherwise:
        // Change our rotation so that we are closer to our target rotation, but never turn faster than our Turn Speed
        //   Note that we use Time.deltaTime because we want to turn in "Degrees per Second" not "Degrees per Framedraw"
        tf.rotation = Quaternion.RotateTowards(tf.rotation, targetRotation, speed * Time.deltaTime);

        // We rotated, so return true
        return true;
    }
}
