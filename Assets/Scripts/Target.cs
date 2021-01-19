using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public Material[] materials;

    private void Start()
    {
        if (materials.Length > 1)
        {
            int color = Random.Range(0, materials.Length - 1);
            GetComponent<Renderer>().material = materials[color];
        }
        else
        {
            GetComponent<Renderer>().material = materials[0];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //add score to game
            Game.Instance.AddPoints(points);
        }
    }
}
