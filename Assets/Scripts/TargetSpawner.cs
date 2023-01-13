using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnGameObject;
    [SerializeField] private float spawnTimeMin = 2;
    [SerializeField] private float spawnTimeMax = 5;

    private float spawnTimer;

    //Set initial spawn timer
    void Start()
    {
        spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    void Update()
    {
        //Check if current target is destroyed
        if (transform.childCount == 0)
        {
            //Check for spawn timer
            if (spawnTimer <= 0)
            {
                //Reset timer and spawn new target
                spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
                Instantiate(spawnGameObject, transform.position, transform.rotation, transform);
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
    }
}
