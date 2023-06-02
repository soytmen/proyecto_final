using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float startDelay = 2f;
    private float repeatRate = 20f;
    private PlayerController playerControllerScript;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = FindObjectOfType<PlayerController>();
    }
    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position,
        obstaclePrefab.transform.rotation);
    }

}
