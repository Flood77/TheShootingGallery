using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.1f;
    public float angle = 10.0f;
    public int ammoMax = 100;
    public GameObject projectile;
    public Transform emitTransform;

    protected int ammo = 100;
    protected float fireTimer = 0;

    void Update()
    {
        fireTimer += Time.deltaTime;
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            GameObject gameObject = Instantiate(this.projectile, position, Quaternion.identity);
            gameObject.GetComponent<Projectile>().Fire(direction);

            fireTimer = 0;
            return true;
        }
        return false;
    }

    public bool Fire(Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            GameObject gameObject = Instantiate(this.projectile, emitTransform.position, emitTransform.rotation);
            gameObject.GetComponent<Projectile>().Fire(direction);

            fireTimer = 0;
            return true;
        }
        return false;
    }
}
