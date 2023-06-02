using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;
public float distanciarayo = 200f;
public float dano = 50;
    private float shotRateTime = 0;
     public AudioClip efectodisparo;
    public AudioSource volumen;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
             volumen.PlayOneShot(efectodisparo);
            if(Time.time>shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet,spawnPoint.position,spawnPoint.rotation);
                Debug.DrawRay(transform.position,spawnPoint.forward * 20, Color.yellow);
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, distanciarayo)){
                    Debug.Log(hit.transform);
if(hit.transform.tag == "enemy"){

    hit.transform.GetComponent<Enemigo>().vidaEnemigo -= dano;

}
                }
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 2);
            }
        }

        
    }
}
