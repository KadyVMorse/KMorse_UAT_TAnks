using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject firePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Shoot()
    {
        //instaniate a bullet

        GameObject ourCannonBall;
        ourCannonBall = Instantiate(cannonBall, firePoint.transform);

        //apply force
      // ourCannonBall.SendMessage("ApplyForce", TankData.)
        
    }
}
