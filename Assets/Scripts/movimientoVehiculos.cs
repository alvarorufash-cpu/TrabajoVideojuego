using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoVehiculos : MonoBehaviour
{
    
    Vector3 movimiento;
    public float tiempoPatrulla;
    public float temporizador;
    SpriteRenderer sprite;
    Rigidbody2D cuerpo;
    public float velocidad;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        movimiento = new Vector3(1,0,0);
        movimiento = new Vector3(1,0,0);
        temporizador = tiempoPatrulla;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       Girar();
       ActualizarTemporizador(); 
    }

    private void ActualizarTemporizador()
    {
        temporizador -= Time.deltaTime;
        if (temporizador < 0)
        {
            movimiento *= -1;
            temporizador = tiempoPatrulla;
        }
    }

    private void Girar()
    {
         if (movimiento.x > 0)
        {
            sprite.flipX = true;
        } 

        else if(movimiento.x < 0)
        {
            sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(movimiento.x * velocidad, cuerpo.velocity.y);
    }
}
