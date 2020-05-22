using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFlow : MonoBehaviour
{

    public event EventHandler OnPlayerEnter;
    public event EventHandler OnPlayerExit;
    BoxCollider2D mapCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        mapCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player is in the zone");
            OnPlayerEnter?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player is leaving the zone");
            OnPlayerExit?.Invoke(this, EventArgs.Empty);
        }
    }
}
