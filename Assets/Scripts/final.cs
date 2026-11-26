using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class final : MonoBehaviour
{
    
    public GameObject explosion;
    public seguirJugador seguirJugador;
    public GameObject TextoFinal;
    public AudioSource altavoz;
    public AudioClip explota;

    void Start()
    {
        altavoz = GetComponent<AudioSource>();
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
                altavoz.enabled = true;
                altavoz.PlayOneShot(explota);
                 explosion.SetActive(true);
                 seguirJugador.enabled = false;
                 TextoFinal.SetActive(true);
            }
        }
    }
}
