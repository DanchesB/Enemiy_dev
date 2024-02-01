using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    public int currentHealth = 1000;

    public void HealthReduce(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                Debug.Log("You Dead!");
            }
        }
    }
}