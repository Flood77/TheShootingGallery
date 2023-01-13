using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI highScoreUI;
    
    private int score = 0;
    private float timer = 90.0f;
    private int highScore = 2000;

    static Game instance = null;
    public static Game Instance { get { return instance; } }
    public eState State { get; set; } = eState.Title;

    public enum eState
    {
        Title, 
        StartGame,
        Game,
        GameOver
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                gameOverScreen.SetActive(false);
                startScreen.SetActive(true);
                highScoreUI.text = string.Format("{0:D4}", highScore);
                break;
            case eState.StartGame:
                startScreen.SetActive(false);
                score = 0;
                timer = 60;
                State = eState.Game;
                GetComponent<AudioSource>()?.Play();
                break;
            case eState.Game:
                timer -= Time.deltaTime;
                timerUI.text = timer.ToString("0");

                if (timer <= 0) State = eState.GameOver;
                break;
            case eState.GameOver:
                gameOverScreen.SetActive(true);
                if (score > highScore) highScore = score;
                break;
            default:
                break;
        }
    }

    public void AddPoints(int points) 
    { 
        score += points;
        scoreUI.text = string.Format("{0:D4}", score);
    }

    public void StartGame()
    {
        State = eState.StartGame;
    }
}
