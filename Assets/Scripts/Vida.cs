using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float valor = 100f; // valor vida
    public Vida padreRef;
    public float multiplicadorDeDano = 1.0f;
    public GameObject textoflotantePrefab;
    public float dañoTotal;

    public void Recibirdano (float dano) // daño de personaje
    {
        dano *= multiplicadorDeDano;
        if(padreRef != null)
        {
            padreRef.Recibirdano(dano);
            return;
        }
        valor -= dano;
     
        if(valor < 0)//no queremos vida negativa en personaje
        {
            valor = 0;
        }

    }

}
