using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Platform
{
    Windows,
    Phone
}

public class TapJesus : MonoBehaviour
{
    public Platform platform;

    private void Update()
    {
        CheckForTheFirstTap();
        CheckIfTheFallingObjWasTapped(platform);
    }

    private void CheckForTheFirstTap()
    {
        if (platform == Platform.Phone)
        {
            if (!SceneLoader.INSTANCE.MainMenuOn && !GameManager.INSTANCE.FirstTap && GameManager.INSTANCE.ControlsON 
                && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
            {
                FirstTap();
            }
        }
        else if (platform == Platform.Windows)
        {
            if (!SceneLoader.INSTANCE.MainMenuOn && !GameManager.INSTANCE.FirstTap && GameManager.INSTANCE.ControlsON && Input.GetMouseButtonDown(0))
            {
                FirstTap();
            }
        }
    }

    private void FirstTap()
    {
        Time.timeScale = 1; // Start the game
        GameManager.INSTANCE.ControlsON = true; // On the first tap start the controls
        SceneLoader.INSTANCE.tapToPlayLabel.SetActive(false); // Close the label

        GameManager.INSTANCE.FirstTap = true;
        GameManager.INSTANCE.GameOver = false;
        GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeJesus>().enabled = true;
    }

    private void CheckIfTheFallingObjWasTapped(Platform platform)
    {
        if (platform == Platform.Phone)
        {
            if (GameManager.INSTANCE.ControlsON && Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.up);
                        if (hit.collider != null && hit.collider.CompareTag("FallingObj"))
                        {
                            hit.collider.GetComponent<FallingObjBehaviour>().BoostUp();
                        }
                    }
                }
            }
        }
        else if (platform == Platform.Windows)
        {
            if (GameManager.INSTANCE.ControlsON && Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);
                if (hit.collider != null && hit.collider.CompareTag("FallingObj"))
                {
                    hit.collider.GetComponent<FallingObjBehaviour>().BoostUp();
                }
            }
        }
    }
}
