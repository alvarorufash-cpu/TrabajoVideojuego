using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letras_teclado : MonoBehaviour
{
   
    public GameObject Tecla1 = null;
    public GameObject Tecla2 = null;
    public GameObject Tecla3 = null;

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
            Tecla1.SetActive(true);
            Tecla2.SetActive(true);
            Tecla3.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jugador"))
        {
            Tecla1.SetActive(false);
        Tecla2.SetActive(false);
        Tecla3.SetActive(false);
        }
    }

}
