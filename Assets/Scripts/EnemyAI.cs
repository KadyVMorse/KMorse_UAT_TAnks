using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float health;
    public float maxhealth = 10.0f;
    public GameObject cannonBall;
    public GameObject firePoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private TankData data;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        data = gameObject.GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        //instaniate a bullet
        if (timeBtwShots <= 0)
        {
            Instantiate(cannonBall, transform.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }

    public void TankDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}

