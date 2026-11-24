using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float borde;
    public float cadencia;
    float tiempoDisparo;
    public Transform disparo;
    public GameObject bala;
    public GameObject cura = null;
    public Transform posicionCuracion;
    public float tiempoPatrulla;
    int direccion;
    public float velocidad;
    public Vector2 tamannoAtaque;
    float temporizador;
    SpriteRenderer sprite;
    Rigidbody2D cuerpo;
    public float distanciaAtaque;
    public LayerMask capaJugador;
    Vector3 movimiento;
    Animator anim;
    public int vidaRestante;

    void Start()
    {
        movimiento = new Vector3(1,0,0);
        cuerpo = GetComponent<Rigidbody2D>();
        temporizador = tiempoPatrulla;
        sprite = GetComponent<SpriteRenderer>();
        cuerpo = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Girar();
        ActualizarTemporizador();
        Atacar();
        ActualizarAnim();
    }

    private void ActualizarAnim()
    {
        if (DetectarJugador())
        {
            anim.SetBool("Detectado", true);
            anim.SetBool("EnAlerta", false);
        }
        else
        {
            anim.SetBool("Detectado", false);
            anim.SetBool("EnAlerta", true);
        }
    }

    private void Atacar()
    {
        tiempoDisparo -= Time.deltaTime;

        if (DetectarJugador() && tiempoDisparo <= 0)
        {
            Disparar();
            tiempoDisparo = cadencia;
        }
    }

    private void Disparar()
    {

        GameObject nuevaBala = Instantiate(bala, disparo.position, disparo.rotation);

        balaEnemigo scriptBala = nuevaBala.GetComponent<balaEnemigo>();
    
        if (sprite.flipX)
        {
            scriptBala.direccion = 1; // Mira a la izquierda
        }
        else
        {
           scriptBala.direccion = -1;  // Mira a la derecha
        }
    }

    private void DaCura()
    {
        if (cura != null)
        {
            GameObject nuevaCuracion = Instantiate(cura, posicionCuracion.position, posicionCuracion.rotation);
            curacion spritCuracion = nuevaCuracion.GetComponent<curacion>();
        }
    }

    private bool DetectarJugador()
    {

        Vector2 origen = (Vector2) transform.position + Vector2.right * movimiento * (tamannoAtaque.x / borde);

       RaycastHit2D rayo = Physics2D.BoxCast(origen, tamannoAtaque, 0, Vector2.right * movimiento, distanciaAtaque, capaJugador
       );

       if (rayo) return true;
       return false;
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

    public void Girar()
    {
         if (movimiento.x > 0)
        {
            sprite.flipX = true;
            disparo.localPosition = new Vector2(0.72f, 0.07f);
        } 

        else if(movimiento.x < 0)
        {
            sprite.flipX = false;
            disparo.localPosition = new Vector2(-0.72f, 0.07f);
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(movimiento.x * velocidad, cuerpo.velocity.y);
    }

    void OnDrawGizmos()
    {

        Vector3 origen = (Vector3) transform.position + Vector3.right * movimiento.x * (tamannoAtaque.x / 2f);

        if (DetectarJugador())
        {
            Gizmos.color = Color.red;
            Atacar();
        }
        Gizmos.DrawWireCube(origen, tamannoAtaque);
        Gizmos.color = Color.white;
    }

    public void RecibeDanno(int cuanto, Vector2 posEnemigo)
    {
        vidaRestante -= cuanto;
        if (vidaRestante <= 0)
        {
          Muerto();
        }
    }

    public void Muerto()
    {
        anim.SetBool("Muerto", true);
        DaCura();
        GetComponent<Rigidbody2D>().simulated = false;
        Destroy(gameObject, 1f);
        
        
    }

}
