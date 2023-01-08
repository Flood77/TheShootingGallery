using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepAwayMenu : MonoBehaviour
{
    void Start()
    {
        KeepAwayController gameController = FindObjectOfType<KeepAwayController>();
        if(gameController == null)
        {
            SceneManager.LoadScene("KeepAwayController", LoadSceneMode.Additive);
        }
        gameController.gameOverScreen.SetActive(true);
    }
}
