using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Jugador : MonoBehaviour
{
    public float cadencia;
    float tiempoDisparo;
    public Transform disparo;
    public GameObject bala;
    public float velocidad;
    public float fuerzaSalto;
    public float distCaja;
    public Vector2 tamannoCaja;
    public LayerMask capaSuelo;
    Vector3 movimiento;
    Rigidbody2D cuerpo;
    bool Saltando;
    SpriteRenderer sprite;
    Animator anim;
    bool girado;
    public int vidaRestante = 3;
    bool agachado = false;
    public float temporizador;

    public Transform reaparece;

    public GameObject[] corazones;
    
    int vidaMaxima = 3;
    public AudioSource altavoz;
    public AudioClip dano;
    public AudioClip sonidoDisparo;

    void Start()
    {
        altavoz = GetComponent<AudioSource>();
        movimiento = new Vector3();
        cuerpo = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
        vidaRestante = vidaMaxima;
        ActualizarCorazones();
    }


    void Update()
    {
        LeerMovimiento();
        LeerSalto();
        RotarPersonaje();
        ActualizarAnim();
        Atacar();
    }

    public void RecibeDanno(int cuanto, Vector2 posEnemigo)
    {

        altavoz.PlayOneShot(dano);

        vidaRestante -= cuanto;
        ActualizarCorazones();
        
        if (vidaRestante <= 0)
        {
            transform.position = reaparece.transform.position;
        }
    }

    public void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(i < vidaRestante);
        }
    }

    private void Disparar()
    {

        altavoz.PlayOneShot(sonidoDisparo);

        GameObject nuevaBala = Instantiate(bala, disparo.position, disparo.rotation);

        Bala scriptBala = nuevaBala.GetComponent<Bala>();
    
            if (sprite.flipX)
            {
                scriptBala.direccion = -1; // Mira a la izquierda
                
            }
            else
            {
                scriptBala.direccion = 1;  // Mira a la derecha
            }    
    }

    private void Atacar()
    {

        tiempoDisparo -= Time.deltaTime;

        if (Input.GetKey(KeyCode.M) && movimiento.x ==0)
        {
            anim.SetBool("Atacar", true);
            anim.SetBool("Dano", false);
        }
        else
        {
            anim.SetBool("Atacar", false);
            anim.SetBool("Dano", false);
        }
        if (Input.GetKey(KeyCode.M) && movimiento.x ==0 && EstaEnElSuelo() && tiempoDisparo <= 0 && agachado == false)
        {
            Disparar();
            tiempoDisparo = cadencia;
        }
    }

    private bool ActualizarAnim()
    {
        if (movimiento.x == 0)
        {
            anim.SetBool("Quieto", true);
        }
        else
        {
            anim.SetBool("Quieto", false);
            anim.SetBool("Dano", false);
        }

        if (!EstaEnElSuelo())
        {
            anim.SetBool("Saltando", true);
            anim.SetBool("Dano", false);
        }
        else
        {
            anim.SetBool("Saltando", false);
        }

        if (Input.GetKey(KeyCode.S) && EstaEnElSuelo() && movimiento.x ==0)
        {
            anim.SetBool("Agachado", true);
            anim.SetBool("Dano", false);
            return agachado = true;

        }
        else
        {
            anim.SetBool("Agachado", false);
            anim.SetBool("Dano", false);
        }

        return agachado = false;
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(movimiento.x * velocidad, cuerpo.velocity.y);
        if (Saltando)
        {  
           cuerpo.AddForce(Vector2.up * fuerzaSalto);
           Saltando = false; 
        }
    }

    private void RotarPersonaje()
    {

        if (movimiento.x < 0)
        {
            sprite.flipX = true;
            disparo.localPosition = new Vector2(-1f, 1.42f);
        } 

        else if(movimiento.x > 0)
        {
            sprite.flipX = false;
            disparo.localPosition = new Vector2(1f, 1.42f);
        }
    }

    private void LeerMovimiento()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movimiento = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimiento = Vector3.right;
        } 
        else
        {
            movimiento = new Vector3();
        }
    }

    private void LeerSalto()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Saltando && EstaEnElSuelo())
        {
            Saltando = true;
        }    
    }

    bool EstaEnElSuelo()
    {
        RaycastHit2D rc = Physics2D.BoxCast(transform.position, tamannoCaja, 0, Vector2.down, distCaja, capaSuelo);
        if (rc)
        {
            return true;
        }
        else
        {
            return false;    
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.down * distCaja, tamannoCaja);
    }

}
