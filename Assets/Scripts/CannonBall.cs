using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float damage;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        //after a certain amount of time bullet disappers
        timer += 1.0F * Time.deltaTime;

        if (timer >= 1)
        {
            GameObject.Destroy(gameObject);
        }
    }

    

    void OnCollisionEnter(Collision collision)
    {
        //Apply damage to what we collided with 
     
        //Destroy the cannon ball if it collides with anything
        Destroy(gameObject);
    }


}
