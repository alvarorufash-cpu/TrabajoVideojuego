using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicion : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl2;
    bool pasar;

    public LayerMask capaJugador;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jugador"))
        {
            if (pasar == false)
            {
                 Camera.main.transform.position = lvl2.transform.position;
                 pasar = true;
            }
            else
            {
                Camera.main.transform.position = lvl1.transform.position;
                pasar = false;
            }  
        }
        
    }
}
