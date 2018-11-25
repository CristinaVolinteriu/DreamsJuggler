using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE = null;
    
    public bool GameOver { get; set; }
    public bool FirstTap { get; set; }
    public bool ControlsON { get; set; }
    public int LostObjects { get; set; }

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
        DontDestroyOnLoad(gameObject);
    }

	void Update ()
    {
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (LostObjects == 3)
        {
            LostObjects = 0;
            FirstTap = false;
            GameOver = true;
            SceneLoader.INSTANCE.GameOver();
            GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeJesus>().enabled = false;
            UIJesus.INSTANCE.SetLostObjectsLabel(3);
        }
    }
}
