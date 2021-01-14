using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
            
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            GameObject gameObject = Instantiate(this.bullet, transform.position, Quaternion.identity);
            gameObject.GetComponent<Bullet>().Fire(ray.direction);
        }
    }
}
