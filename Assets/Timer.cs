using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private StoveManager stoveManager;
    public TMP_Text timerText;

    public float defaultTime;
    private float timer;

    private bool buttonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
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
        timer = defaultTime;
        buttonPressed = true;
    }

    void DisplayTime(float currentTimer)
    {
        float seconds = Mathf.FloorToInt(currentTimer % 60);
        float milliseconds = currentTimer % 1 * 1000;

        timerText.text = string.Format("{0:00}: {1:000}", seconds, milliseconds);
    }
}
