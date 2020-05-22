using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{

    // Este script se utiliza para activar o desactivar
    // elementos en un mapa dependiendo de si el player
    // ha entrado en el mapa o ha salido
    // Se adjunta al prefab del objeto que se quiere que se active
    // siguiendo el comportamiento descrito arriba.


    public MapFlow script;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
        script = transform.parent.GetComponent<MapFlow>();
        script.OnPlayerEnter += Script_OnPlayerEnter;
        script.OnPlayerExit += Script_OnPlayerExit;
    }

    private void Script_OnPlayerExit(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void Script_OnPlayerEnter(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }

}
