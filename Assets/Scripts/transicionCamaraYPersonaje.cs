using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicionCamaraYPersonaje : MonoBehaviour
{
   public GameObject jugador;

    public GameObject aparece;

    bool pasar;

    public LayerMask capaJugador;


    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Jugador"))
        {
            jugador.transform.position = aparece.transform.position;
        }
        
    }
}
