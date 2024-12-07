using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    [SerializeField] private int healthPointsToAdd;
    protected override void PickMeUp(Player playerInTrigger)
    {

        playerInTrigger.healthValue.IncreaseHealth(healthPointsToAdd);
        Destroy(gameObject);
    }
}
