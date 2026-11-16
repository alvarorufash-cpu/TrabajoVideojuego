using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
   public float velocidad;
   Rigidbody2D cuerpo;
   int direccion;
    public LayerMask capaEnemigo;
    SpriteRenderer sprite;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        direccion = 1;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(direccion*velocidad, cuerpo.velocity.y);
    }

}
