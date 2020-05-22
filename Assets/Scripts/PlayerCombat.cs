using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public PlayerResources script;

    // Start is called before the first frame update
    void Start()
    {
        script = GetComponent<PlayerResources>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Debug.Log("Hit taken");
            script.DamageTaken(1);
        }
    }
}
