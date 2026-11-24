using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirJugador : MonoBehaviour
{
    public Transform player;


    void Start()
    {
        
    }


    void FixedUpdate()
    {
        Vector3 posDestino = player.position;
        Vector3 posicionVieja = transform.position;

        float objetivoY = posDestino.y + 2;
        float ObjetivoX = posDestino.x + 3;

        Vector3 posNueva = new Vector3(
            Mathf.Lerp(posicionVieja.x, ObjetivoX, 5* Time.fixedDeltaTime), objetivoY, posicionVieja.z
        );
        transform.position = posNueva;
    }
}
