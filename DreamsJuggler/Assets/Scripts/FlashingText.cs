using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    private Text flashingText;
    public string textToFlash = "Tap anywhere to start";
    public string blankText = "";
    
    public bool Blink { get; set; }

    void Start()
    {
        flashingText = GetComponent<Text>();
        flashingText.text = blankText;
    }
    
    public IEnumerator BlinkText()
    {
        while (Blink)
        {
            flashingText.text = blankText;
            yield return new WaitForSeconds(.5f);
            flashingText.text = textToFlash;
            yield return new WaitForSeconds(.5f);
        }
    }

    public void ResetText()
    {
        flashingText.text = blankText;
    }

    public void StartText()
    {
        flashingText.text = textToFlash;
    }
}
