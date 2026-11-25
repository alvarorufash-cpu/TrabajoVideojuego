using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class final : MonoBehaviour
{
    
    public GameObject explosion;
    public seguirJugador seguirJugador;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jugador"))
        {
            if (seguirJugador != null)
            {
                 explosion.SetActive(true);
                 seguirJugador.enabled = false;
            }
        }
    }
}
