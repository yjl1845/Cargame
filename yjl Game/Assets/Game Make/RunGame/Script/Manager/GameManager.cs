using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        GameOver();
    }



    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
    }
}
