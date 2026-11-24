using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperCristales : MonoBehaviour
{
    
    public GameObject ventanas;
    

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
            ventanas.SetActive(false);
        }
    }
}
