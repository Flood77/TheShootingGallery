using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int Score { get; set; } = 0;
    //public int HighScore { get; set; } = 2000;
    public TextMeshProUGUI scoreUI;
    //public TextMeshProUGUI highScoreUI;
    //public TextMeshProUGUI timerUI;
    public GameObject startScreen;
    public GameObject gameOverScreen;

    static Game instance = null;

    //float timer = 90.0f;

    public enum eState
    {
        Title, 
        StartGame,
        Game,
        GameOver
    }

    public eState State { get; set; } = eState.Title;

    private void Awake()
    {
        instance = this;   
    }

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                gameOverScreen.SetActive(false);
                startScreen.SetActive(true);
                break;
            case eState.StartGame:
                startScreen.SetActive(false);
                Score = 0;
                //timer = 90;
                State = eState.Game;
                GetComponent<AudioSource>().Play();
                break;
            case eState.Game:
                AddPoints((int)(Time.deltaTime * 100));
                //timerUI.text = timer.ToString("0");

                //if (timer <= 0) State = eState.GameOver;
                break;
            case eState.GameOver:
                gameOverScreen.SetActive(true);
                //if (Score > HighScore) HighScore = Score;
                break;
            default:
                break;
        }
        //highScoreUI.text = string.Format("{0:D4}", HighScore);
    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }

    public void AddPoints(int points) 
    { 
        Score += points;
        scoreUI.text = string.Format("{0:D4}", Score);
    }

    public void StartGame()
    {
        State = eState.StartGame;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Controller");
    }
}
