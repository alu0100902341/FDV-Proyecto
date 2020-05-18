using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpMap : MonoBehaviour
{

    public event EventHandler OnPlayerEnter;
    BoxCollider2D mapCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        mapCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Sub_OnPlayerEnter(object sender, EventArgs e)
    {
        Debug.Log("Time To Wake Up");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player is in the zone");
            OnPlayerEnter?.Invoke(this, EventArgs.Empty);
        }
    }
}
