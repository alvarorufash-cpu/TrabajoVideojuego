using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraVida : MonoBehaviour
{
    public Image rellenoVida;
    Jugador jugador;
    float vidaMaxima;

    void Start()
    {
        jugador = GetComponent<Jugador>();
        vidaMaxima = jugador.vidaRestante;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoVida.fillAmount = jugador.vidaRestante / vidaMaxima;
    }
}
