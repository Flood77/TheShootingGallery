using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI timerUI;
    public GameObject startScreen;
    public UnityEvent startSessionEvents;

    static GameSession instance = null;
    public static GameSession Instance
    {
        get
        {
            return instance;
        }
    }

    public enum eState
    {
        StartSession, 
        Session,
        EndSession,
        GameOver
    }

    public eState State { get; set; } = eState.StartSession;

    private void Awake()
    {
        instance = this;   
    }

    private void Start()
    {

    }

    private void Update()
    {
        switch (State)
        {
            case eState.StartSession:
                Score = 0;
                startSessionEvents?.Invoke();
                GameController.Instance.transition.StartTransition(Color.clear, 1);
                State = eState.Session;
                break;
            case eState.Session:
                break;
            case eState.GameOver:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                break;
        }
    }

    public void AddPoints(int points) 
    { 
        Score += points;
        scoreUI.text = string.Format("{0:D4}", Score);
    }
}
