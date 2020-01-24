using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float damage;
    public float timer;
    public float cannonShelfLife = 1.5f;
    public GameObject shooter;

    void Start()
    {
        if (damage == 0)
        {
            damage = 10;
        }
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

    private void OnTriggerEnter(Collider other)
    {

        TankData otherObjData = other.gameObject.GetComponent<TankData>();


        if (otherObjData != null)
        {

            otherObjData.updateHealth(damage);
            //  AudioSource.PlayClipAtPoint(hit, Vector3.zero);

            shooter.GetComponent<TankData>().updateDamageDone(damage);


            if (otherObjData.health <= 0)
            {
                Destroy(other.gameObject);


            }




        }
    }
}
