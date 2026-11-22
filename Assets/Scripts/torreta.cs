using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta : MonoBehaviour
{
    public float borde;
    public float cadencia;
    float temporizador;
    public Transform disparo;
    public GameObject bala;
    int direccion;
    public Vector2 tamannoAtaque;
    SpriteRenderer sprite;
    public float distanciaAtaque;
    public LayerMask capaJugador;
    Vector3 movimiento;
    bool disparando;
    public float tiempoDisparo;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Atacar();
    }

    private void Atacar()
    {
        temporizador -= Time.deltaTime;

        if (DetectarJugador() && temporizador <= 0 && disparando == false)
        {
            disparando = true;
            temporizador = tiempoDisparo;
        }

        if (disparando == true)
        {
            Disparar();
            temporizador --; 

            if (temporizador <= 0)
            {
                disparando = false; 
            }
        }
    }

    private void Disparar()
    {

        if (bala != null)
        {
            GameObject nuevaBala = Instantiate(bala, disparo.position, disparo.rotation);

        balaEnemigo scriptBala = nuevaBala.GetComponent<balaEnemigo>();
        scriptBala.direccion = -1; 
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

}
