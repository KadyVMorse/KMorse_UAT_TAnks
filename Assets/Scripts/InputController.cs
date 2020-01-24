using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when this code is put on object it will add these as well because its required
[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]
public class InputController : MonoBehaviour
{
    // variables of differnt objects and the input is wasd and arrow keys also sets the boolean if the tank can shoot
    public enum InputScheme { WASD, arrowKeys };
    public InputScheme input = InputScheme.WASD;
    private TankData data;
    private TankMotor motor;
    private TankShooter shooter;
    private float timeUntilcanShoot;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<TankData>();
        motor = gameObject.GetComponent<TankMotor>();
        shooter = gameObject.GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player can shoot then it will get the key of space and shootbut if can shoot is false thean it will wait to fire
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //shoot
                shooter.Shoot();
                canShoot = false;
                timeUntilcanShoot = data.fireRate;

            }
        }

        //if you are wait if it shoots the time until shoot will subtract from the time till you can unless you can shoot
        if (timeUntilcanShoot > 0) 
        {
            timeUntilcanShoot -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
        }

        //sets up the input and what they equal to on the tank
        switch (input)
        {
            case InputScheme.arrowKeys:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    motor.Move(data.moveSpeed);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    motor.Move(-data.reverseSpeed);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    motor.Rotate(data.rotateSpeed);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    motor.Rotate(-data.rotateSpeed);
                }
                break;
            case InputScheme.WASD:
                if (Input.GetKey(KeyCode.W))
                {
                    motor.Move(data.moveSpeed);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    motor.Move(-data.reverseSpeed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    motor.Rotate(data.rotateSpeed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    motor.Rotate(-data.rotateSpeed);
                }
                break;
        }
    }
}
