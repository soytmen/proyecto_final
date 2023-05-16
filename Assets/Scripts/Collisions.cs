using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public int Points;
    public Transform coins;
    public int totalCoins;
    void Start()
    {
        totalCoins = coins.childCount;
    }


    void Update()
    {
       
        if (totalCoins == 10)
        {
            Debug.Log($"You Win");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("obstacle"))
        {
            Points--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Coins"))
        {
            Destroy(other.gameObject);
            Points += 1;
            totalCoins ++;
        }



    }
}
