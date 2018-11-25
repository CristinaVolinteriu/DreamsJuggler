using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreJesus : MonoBehaviour
{
    public static HighscoreJesus INSTANCE = null;

    private int fallingObjHighScore;
    private float timeHighScore;
    private float actualyPlayTime;
    private Text highscoreText;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            if (INSTANCE != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        fallingObjHighScore = PlayerPrefs.GetInt("FallingObjHighscore");
        timeHighScore = PlayerPrefs.GetFloat("TimeHighscore");
    }

    private void Update()
    {
        UIJesus.INSTANCE.SetHighScoreLabels(fallingObjHighScore, timeHighScore);
    }

    public void SetNewBest(int numberOfFallingObj, float time)
    {
        if (GameManager.INSTANCE.ControlsON)
        {
            if (numberOfFallingObj > fallingObjHighScore)
            {
                fallingObjHighScore = numberOfFallingObj;
                timeHighScore = time;
                PlayerPrefs.SetInt("FallingObjHighscore", fallingObjHighScore);
                PlayerPrefs.SetFloat("TimeHighscore", time);
            }
            else
            {
                if (numberOfFallingObj == fallingObjHighScore && time > timeHighScore)
                {
                    timeHighScore = time;
                    PlayerPrefs.SetFloat("TimeHighscore", time);
                }
            }
        }
    }
}
