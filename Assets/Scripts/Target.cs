using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject destroy;
    [SerializeField] private Material[] materials;

    private int points = 100;
    private int[] scores = { 100, 300, 500, 800 };

    //Randomize targets color and point value
    private void Start()
    {
        int choice = Random.Range(0, materials.Length);
        GetComponent<Renderer>().material = materials[choice];
        points = scores[choice];
    }

    //When shot destroy target and add score
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Game.Instance.AddPoints(points);
            Destroy(destroy);
        }
    }
}
