using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(forward * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Object.Destroy(this);
    }
}
