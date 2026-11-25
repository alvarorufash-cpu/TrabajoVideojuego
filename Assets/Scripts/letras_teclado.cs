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
            if(Tecla1 != null) Tecla1.SetActive(true);
            if(Tecla2 != null) Tecla2.SetActive(true);
            if(Tecla3 != null)Tecla3.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jugador"))
        {
            if(Tecla1 != null) Tecla1.SetActive(false);
            if(Tecla2 != null) Tecla2.SetActive(false);
            if(Tecla3 != null) Tecla3.SetActive(false);
        }
    }

}
