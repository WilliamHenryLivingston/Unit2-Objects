using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverDrive : PickUp
{

    [SerializeField] private float speedMultiplier = 2f; // How much to multiply the speed by
    [SerializeField] private float duration = 5f; //How long overdrive lasts
    protected override void PickMeUp(Player playerInTrigger)
    {
        if (playerInTrigger !=null)
        {
            StartCoroutine(ApplySpeedBoost(playerInTrigger));

        }

    }

    private IEnumerator ApplySpeedBoost(Player player)
    {

        float originalSpeed = player.movementSpeed;
        player.movementSpeed *= speedMultiplier; // Boost the speed
        

        yield return new WaitForSeconds(duration); // Wait for the duration of the boost
        

        player.movementSpeed = originalSpeed; // Reset the speed
        Destroy(gameObject);


    }
}
