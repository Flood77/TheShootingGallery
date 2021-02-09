using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifespan = 1;
    public float angle = 0.0f;
    public bool destroyOnHit = false;
    public GameObject destroyFX;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnDestroy()
    {
        if(destroyFX != null)
        {
            GameObject gameObject = Instantiate(destroyFX, transform.position, transform.rotation);
            Destroy(gameObject, 1);
        }
    }

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.right);
        rigidBody.AddForce(rotation * forward * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
