using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Transform tf;
    private TankData data;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 speedVector = tf.forward *speed;

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
        Vector3 rotateVector = Vector3.up*speed*Time.deltaTime;

        // Start by rotating right by one degree per frame draw. Left is just "negative right".


        // Now, rotate our tank by this value - we want to rotate in our local space (not in world space).
       tf.Rotate(rotateVector,Space.Self);
    }
}
