using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar script;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        script.SetMaxHealth(maxHealth);
    }

    public void DamageTaken(int damage)
    {
        currentHealth -= damage;
        script.SetHealth(currentHealth);
    }
}
