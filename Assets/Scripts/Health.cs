using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float decay;
    public Slider slider;
    public Game game;
    public bool destroyOnDeath = false;

    public float health;

    void Start()
    {
        health = healthMax;
    }

    void Update()
    {

        if (slider != null)
        {
            if (game.State == Game.eState.Game)
            {
                AddHealth(-Time.deltaTime * decay);
            }
            slider.value = health / healthMax;
        }
        if (health <= 0 && destroyOnDeath) GameObject.Destroy(gameObject);
    }

    public void AddHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, healthMax);
    }
}
