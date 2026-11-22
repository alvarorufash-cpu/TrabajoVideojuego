using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordenador : MonoBehaviour
{

    public torreta torreta;
    bool jugadorDentro;
    public LayerMask capaJugador;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (jugadorDentro && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("He presionado la tecla Q dentro del ordenador");
            torreta.bala = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("El jugador esta en el ordenador");
           jugadorDentro = true;
    }

}
