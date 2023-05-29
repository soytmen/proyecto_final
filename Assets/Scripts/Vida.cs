using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vida : MonoBehaviour
{
    public float valor = 100f; // valor vida

    public float multiplicadorDeDano = 1.0f;
    public GameObject textoflotantePrefab;
    public float danoTotal;
public TMP_Text textovida;
    public void Recibirdano (float dano) // dano de personaje
    {
        dano *= multiplicadorDeDano;
       
        valor -= dano;
     textovida.text = valor.ToString("0");
        if(valor <= 0)//no queremos vida negativa en personaje
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        Debug.Log(valor);

    }
    

}
