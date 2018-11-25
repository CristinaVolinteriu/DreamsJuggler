using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite soundOnImage;
    public Sprite soundOffImage;

    private bool soundOn = true;
    private Image soundImage;

    private void Start()
    {
        soundImage = GetComponent<Image>();
        soundOn = PlayerPrefs.GetInt("SoundChoice") == 1 ? true : false;
        ChangeIcon();
        StartSound();
    }

    private void ChangeIcon()
    {
        if (soundOn)
        {
            soundImage.sprite = soundOnImage;
        }
        else
        {
            soundImage.sprite = soundOffImage;
        }
    }

    private void StartSound()
    {
        if (soundOn)
        {
            audioSource.Play();
        }
    }

    public void SetSound()
    {
        if (soundOn)
        {
            soundOn = false;
            audioSource.Stop();
            PlayerPrefs.SetInt("SoundChoice", 0);
        }
        else
        {
            soundOn = true;
            audioSource.Play();
            PlayerPrefs.SetInt("SoundChoice", 1);
        }
        ChangeIcon();
    }
}
