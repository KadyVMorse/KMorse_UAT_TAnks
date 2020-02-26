using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Powerup : MonoBehaviour
{
    public float speedModifier;
    public float heatlthModifier;
    public float maxHealthModifier;
    public float fireRateModifier;

    public float duration;
    public bool isPermanent;

    public void OnActivate(TankData target)
    {
        target.moveSpeed += speedModifier;
        target.health += heatlthModifier;
        target.maxHealth += maxHealthModifier;
        target.fireRate += fireRateModifier;
    }
    public void OnDeactivate(TankData target)
    {
        target.moveSpeed -= speedModifier;
        target.health -= heatlthModifier;
        target.maxHealth -= maxHealthModifier;
        target.fireRate -= fireRateModifier;
    }


}
