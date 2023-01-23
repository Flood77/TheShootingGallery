using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float angle = 0.0f;
    [SerializeField] private float lifespan = 1;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private AudioSource bounce;
    [SerializeField] private AudioSource hit;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    public void Fire(Vector3 forward)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.right);
        GetComponent<Rigidbody>().AddForce(rotation * forward * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>() != null) hit.Play();
        else bounce.Play();
    }
}
