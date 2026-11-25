using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class poweUp : MonoBehaviour
{
    Vector2 movimiento;
    Rigidbody2D cuerpo;
    float velocidad = -1f;
    public float tiempo;
    public float cambio;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        movimiento = new Vector2(0f, 1f);
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= cambio)
        {
            velocidad *= -1f;
            tiempo = 0;
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(cuerpo.velocity.x, movimiento.y * velocidad);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jugador"))
        {
            Jugador jugador = collision.GetComponent<Jugador>();

            jugador.velocidad *= 2f;
            jugador.cadencia =0.3f;

            Destroy(gameObject);
        }
    }
}
