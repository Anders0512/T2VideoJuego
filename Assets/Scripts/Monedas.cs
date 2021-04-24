using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monedas : MonoBehaviour
{
    private int moneda = 0;
    public Text puntaje;

    public int Contar()
    {
        return moneda;
    }
    public void Puntos(int moneda)
    {
        this.moneda += moneda;
        puntaje.text = "Puntaje: " + Contar();
    }
}