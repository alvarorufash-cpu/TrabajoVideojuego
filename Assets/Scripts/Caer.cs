using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caer : MonoBehaviour
{   
    public Transform reaparece;
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
            collision.transform.position = reaparece.transform.position;
        }
    }
}
