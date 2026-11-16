using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    
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

    void Start()
    {
        movimiento = new Vector3();
        cuerpo = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        LeerMovimiento();
        LeerSalto();
        RotarPersonaje();
        ActualizarAnim();
        Atacar();
    }

    private void Atacar()
    {
        if (Input.GetKey(KeyCode.M) && movimiento.x ==0)
        {
            anim.SetBool("Atacar", true);
            
        }
        else
        {
            anim.SetBool("Atacar", false);
        }
    }

    private void ActualizarAnim()
    {
        if (movimiento.x == 0)
        {
            anim.SetBool("Quieto", true);
        }
        else
        {
            anim.SetBool("Quieto", false);
        }

        if (!EstaEnElSuelo())
        {
            anim.SetBool("Saltando", true);
        }
        else
        {
            anim.SetBool("Saltando", false);
        }

        if (Input.GetKey(KeyCode.S) && EstaEnElSuelo() && movimiento.x ==0)
        {
            anim.SetBool("Agachado", true);
        }
        else
        {
            anim.SetBool("Agachado", false);
        }

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
        } 
        else if(movimiento.x > 0)
        {
            sprite.flipX = false;
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
            Debug.Log("Esta en el suelo");
            return true;
        }
        else
        {
            Debug.Log("No esta en el suelo");
            return false;    
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.down * distCaja, tamannoCaja);
    }

}
