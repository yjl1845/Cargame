using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text bestscore;

    private void Start()
    {
        scoreText.text = "Score : " + DataManager.instance.Score;
    }

    public void IncreaseScore()
    {
        DataManager.instance.Score += 100;

        if (PlayerPrefs.GetInt("SCORE") <= DataManager.instance.Bestscore)
        {
            DataManager.instance.Bestscore = DataManager.instance.Score;
            bestscore.text = "Best Score : " + DataManager.instance.Bestscore;
        }
        
        scoreText.text = "Score : " + DataManager.instance.Score;
    }

    public void ResetScore()
    {
        DataManager.instance.Score = 0;
        scoreText.text = "Score : " + DataManager.instance.Score;
    }

    public void ResetBestScore()
    {
        DataManager.instance.Bestscore = 0;
        DataManager.instance.Score = 0;
        bestscore.text = "Best Score : " + DataManager.instance.Bestscore;
    }

    public void SaveScore()
    {
        DataManager.instance.Save();
    }
}
