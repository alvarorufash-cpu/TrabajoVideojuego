using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoIndicador : MonoBehaviour
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
            velocidad *= -1;
            tiempo = 0;
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(cuerpo.velocity.x, movimiento.y * velocidad);
    }

}
