using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordenador : MonoBehaviour
{

    public torreta torreta;
    bool jugadorDentro;
    public LayerMask capaJugador;
    Animator anim;
    public GameObject powerUp;
    public Transform posicion;
     int contador = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.Q))
        {

            if (contador == 0)
            {
                GameObject nuevoPowerUp = Instantiate(powerUp, posicion.position, posicion.rotation);
                contador = 1;
            }
            torreta.bala = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        jugadorDentro = true;
    }

}
