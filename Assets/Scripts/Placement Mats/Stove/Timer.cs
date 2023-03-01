using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private StoveManager stoveManager;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private float defaultTime;
    private float timer;
    private float startTime;

    private bool buttonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime < defaultTime)
        {
            timer = Time.time - startTime;
        }
        else
        {
            timer = 0;
            if (buttonPressed)
            {
                buttonPressed = false;
                stoveManager.CheckForCreatedRecipes();
            }
        }

        DisplayTime(timer);
    }

    public void OnButtonPress()
    {
        startTime = Time.time;
        timer = defaultTime;
        buttonPressed = true;
        stoveManager.StartCooking();
    }

    void DisplayTime(float currentTimer)
    {
        float seconds = Mathf.FloorToInt(currentTimer % 60);
        float milliseconds = currentTimer % 1 * 1000;

        timerText.text = string.Format("{0:00}: {1:000}", seconds, milliseconds);
    }
}
