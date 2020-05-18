using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject target; // Objetivo del warp

    // Evento de colisión con el warp
    void OnTriggerEnter2D(Collider2D _object)
    {
        if (_object.tag == "Player")
            _object.transform.position = target.transform.position;

    }
}
