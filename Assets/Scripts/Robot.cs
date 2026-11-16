using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float tiempoPatrulla;
    int direccion;
    public float velocidad;
    public Vector2 tamannoAtaque;
    float temporizador;
    SpriteRenderer sprite;
    Rigidbody2D cuerpo;
    public float distanciaAtaque;
    public LayerMask capaJugador;

    void Awake()
    {
        direccion = 1;
    }
    void Start()
    {
        temporizador = tiempoPatrulla;
        sprite = GetComponent<SpriteRenderer>();
        cuerpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Girar();
        ActualizarTemporizador();
        DetectarJugador();
    }

    private bool DetectarJugador()
    {
       RaycastHit2D rayo = Physics2D.BoxCast(
        transform.position, tamannoAtaque, 0, Vector2.right * direccion, distanciaAtaque, capaJugador
       );

       if (rayo) return true;
       return false;
    }

    private void ActualizarTemporizador()
    {
        temporizador -= Time.deltaTime;
        if (temporizador < 0)
        {
            direccion *= -1;
            temporizador = tiempoPatrulla;
        }
    }

    private void Girar()
    {
       if (direccion >= 0)
       {
        sprite.flipX = true;
       }
       else
       {
        sprite.flipX = false;
       }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(direccion*velocidad, cuerpo.velocity.y);
    }

    void OnDrawGizmos()
    {
        if (DetectarJugador())
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(transform.position + Vector3.right * direccion * distanciaAtaque,
            tamannoAtaque
        );
        Gizmos.color = Color.white;
    }

}
