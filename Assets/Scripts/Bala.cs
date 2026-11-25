using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
   public float velocidad;
   Rigidbody2D cuerpo;
   public int direccion;
    public LayerMask capaEnemigo;
    SpriteRenderer sprite;
    Animator anim;
    public float temporizador;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      tiempoVida();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            Destroy(gameObject);
           Robot robot = collision.GetComponent<Robot>();
           robot.RecibeDanno(1, transform.position);
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(direccion*velocidad, cuerpo.velocity.y);
    }

    void tiempoVida()
    {
        temporizador  -= Time.deltaTime;
       
        if (temporizador <= 0)
        {
            Destroy(gameObject);
        }
    }

}
