using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore
{
    public void Save(int highscore)
    {
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.Save();
    }
    public int Load()
    {
        if(PlayerPrefs.HasKey("HighScore")) return PlayerPrefs.GetInt("HighScore");
        return 0;
    }
}
