using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public enum eType
    {
        TimerRepeat,
        TimeOneTime,
        Event
    }

    public GameObject spawnGameObject;
    public float spawnTimeMin = 2;
    public float spawnTimeMax = 5;
    public int lives = 3;
    public bool IsSpawnChild = true;
    public eType type = eType.TimerRepeat;
    public GameSession gameS;
    public TextMeshProUGUI txtlives;

    float spawnTimer;

    void Start()
    {
        if (type != eType.Event)
        {
            spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
        }
    }

    void Update()
    {
        switch (type)
        {
            case eType.TimerRepeat:
                if (transform.childCount == 0)//&& Game.Instance.State == Game.eState.Game)
                {
                    spawnTimer -= Time.deltaTime;
                }
                if (spawnTimer <= 0)
                {
                    spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
                    OnSpawn();
                }
                break;
            case eType.TimeOneTime:
                if (transform.childCount == 0)//&& Game.Instance.State == Game.eState.Game)
                {
                    spawnTimer -= Time.deltaTime;
                }
                if (spawnTimer <= 0 && transform.childCount == 0)
                {
                    OnSpawn();
                }
                break;
            case eType.Event:
                if (transform.childCount == 0) OnSpawn();
                break;
            default:
                break;
        }
        txtlives.text = lives.ToString();
    }

    public void OnSpawn()
    {
        Transform parent = (IsSpawnChild) ? transform : null;
        Instantiate(spawnGameObject, transform.position, transform.rotation, parent);
        if (type == eType.Event)
        {
            lives--;
            if (lives <= -1) gameS.State = GameSession.eState.GameOver;
        }

    }
}
