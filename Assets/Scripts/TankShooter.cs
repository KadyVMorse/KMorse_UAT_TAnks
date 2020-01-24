using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    //variables of game object and of the tank data
    public GameObject cannonBall;
    public GameObject firePoint;

    private TankData data;

    // Start is called before the first frame update
    void Start()
    {
        // defines the data 
        data = gameObject.GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Shoot()
    {
        //instaniate a bullet

        GameObject ourCannonBall = Instantiate(cannonBall, firePoint.transform.position, firePoint.transform.rotation);
        CannonBall cannonBallComponet = ourCannonBall.GetComponent<CannonBall>();
        Rigidbody cannonBody = ourCannonBall.GetComponent<Rigidbody>();
        //apply force
   
        cannonBody.AddForce(data.shellForce * transform.forward, ForceMode.Impulse);

        //tell how much damage the cannon ball should do
        cannonBallComponet.damage = data.damageDone;
    }
}
