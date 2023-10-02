using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private int score;
    private int bestscore = 0;

    public int Score
    {

        get { return score; }
        set { score = value; }
    }

    public int Bestscore
    {
        get { return bestscore; }
        set { bestscore = value; }
    }

    public static DataManager instance;

    private void Awake()
    {
        Load();

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("SCORE", score);
    }

    public void Load()
    {
        score = PlayerPrefs.GetInt("SCORE");
    }
}
