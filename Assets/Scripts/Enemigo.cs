using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public float rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool muerto;
    public NavMeshAgent agente;
    public float distancia_ataque;
    public float radio_vision;
    public float vidaEnemigo;
    private void Start()
    {
    
 vidaEnemigo = 100;
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        agente = GetComponent<NavMeshAgent>();
        ani.SetBool("run", true);
    }
    public void Comportamiento_Enemigo()
    {

        float distancia = Vector3.Distance(transform.position, target.transform.position);

        if (distancia > 2)
        {
            agente.isStopped = false;

            agente.SetDestination(target.transform.position);
            return;
        }
        else
        {
            agente.isStopped=true;
        }

        if (distancia <= 2f && rutina <= 0)
        {
            ani.SetBool("attack", true);
            rutina = 2f;
            target.GetComponent<Vida>().Recibirdano(20);

        }


        if (rutina >= 0f){
            rutina -= Time.deltaTime;
        }
    }


    private void Update()
    {
        if(muerto){
            agente.Stop();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            transform.position += Vector3.up * -1;
            return;
        }
        if (vidaEnemigo <= 0)
        {
            muerto = true;

            ani.SetBool("death", true);
            Destroy(gameObject, 5f);
        }
        Comportamiento_Enemigo();
    }
}
