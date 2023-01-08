using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public int[] scores = { 100, 300, 500, 800 };
    public Material[] materials;
    public GameObject destroyGameObject;

    private void Start()
    {
        if (materials.Length > 1)
        {
            int choice = Random.Range(0, materials.Length);
            GetComponent<Renderer>().material = materials[choice];
            points = scores[choice];
        }
        else
        {
            GetComponent<Renderer>().material = materials[0];
            points = scores[0];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //add score to game
            Game.Instance.AddPoints(points);
            if (destroyGameObject != null)
            {
                Destroy(destroyGameObject);
            }
        }
    }
}
