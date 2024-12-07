using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverBoost : PickUp
{

    [SerializeField] private float healthBoostAmount = 1000f;
    [SerializeField] private float boostDuration = 20f;
    protected override void PickMeUp(Player playerInTrigger)
    {

        if (playerInTrigger != null)
        {
            Debug.Log("OverBoost picked up!");
            StartCoroutine(ApplyOverBoost(playerInTrigger));

        }

        Destroy(gameObject);

    }

    private IEnumerator ApplyOverBoost(Player player)
    {
        Debug.Log("Starting OverBoost effect...");
        Health playerHealth = player.GetHealth();

        float originalHealth = playerHealth.GetHealthValue();
        Debug.Log($"Original Health: {originalHealth}");


        playerHealth.IncreaseHealth(healthBoostAmount);
        Debug.Log($"Health after boost: {playerHealth.GetHealthValue()}");

        yield return new WaitForSeconds(boostDuration);

        float boostedHealth = playerHealth.GetHealthValue();
        float excessHealth = boostedHealth - originalHealth;
        Debug.Log($"Boosted Health: {boostedHealth}, Excess Health: {excessHealth}");


        float amountToDecrease = Mathf.Min(healthBoostAmount, excessHealth);
        Debug.Log($"Reverting health by: {amountToDecrease}");

        playerHealth.DecreaseHealth(amountToDecrease);
        Debug.Log($"Final Health: {playerHealth.GetHealthValue()}");

    }


}
