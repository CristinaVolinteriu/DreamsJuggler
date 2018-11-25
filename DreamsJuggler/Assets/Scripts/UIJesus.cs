using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJesus : MonoBehaviour
{
    public static UIJesus INSTANCE = null;

    public Text fallingObjHighscoreLabel;
    public Text timeHighscoreLabel;
    public Text objectsJuggledLabel;
    public Text timeLabel;
    public Text lostObjectsLbel;

    void Awake()
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
    }

    private void Start()
    {
        SetUILabelsOnStart();
    }

    /// <summary>
    /// This doesn't set the highscore labels, those are set in the game manager
    /// </summary>
    public void SetUILabelsOnStart()
    {
        SetObjectsJuggledLabel(0);
        SetTimeLabel(0.00f);
    }

    public void SetHighScoreLabels(int fallingObjHighScore, float timeHighScore)
    {
        SetEggsHighScoreLabel(fallingObjHighScore);
        SetTimeHighScoreLabel(timeHighScore);
    }

    public void SetCurrentScoreLabels(int fallingObj, float time, int lostObjects)
    {
        SetObjectsJuggledLabel(fallingObj);
        SetTimeLabel(time);
        SetLostObjectsLabel(lostObjects);
    }

    private void SetEggsHighScoreLabel(int numberOfFallingObjects)
    {
        fallingObjHighscoreLabel.text = "Dreamcatchers highscore " + numberOfFallingObjects;
    }

    private void SetTimeHighScoreLabel(float time)
    {
        timeHighscoreLabel.text = "juggled for " + time.ToString("0.##") + " s";
    }

    private void SetObjectsJuggledLabel(int numberOfFallingObj)
    {
        objectsJuggledLabel.text = numberOfFallingObj.ToString();
    }

    private void SetTimeLabel(float time)
    {
        timeLabel.text = time.ToString("0.##");
    }

    public void SetLostObjectsLabel(int numberOfLostObjects)
    {
        lostObjectsLbel.text = numberOfLostObjects.ToString();
    }
}
