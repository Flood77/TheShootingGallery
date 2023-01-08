using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    public float lifeTime = 5;

    void Start()
    {
        GameObject.Destroy(gameObject, lifeTime);
    }
}
