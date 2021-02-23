using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float spawnTimeMin = 2;
    public float spawnTimeMax = 5;
    public bool IsSpawnChild = true;

    float spawnTimer;

    void Start()
    {
        spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
    }
    void Update()
    {
        if (transform.childCount == 0 )//&& Game.Instance.State == Game.eState.Game)
        {
            spawnTimer -= Time.deltaTime;
        }
        if(spawnTimer <= 0)
        {
            spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
            Transform parent = (IsSpawnChild) ? transform : null;
            Instantiate(spawnGameObject, transform.position, transform.rotation, parent);
        }
    }
}