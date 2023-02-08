using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    [SerializeField]
    private TextMeshProUGUI moneyDisplay;
    private float currentMoney;
    /*
    [SerializeField]
    private TextMeshProUGUI timeDisplay;
    [SerializeField]
    private float currentTime;
    */

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //implement enabling pause menu here
        }
    }

    public static GameStateManager GetInstance()
    {
        return _instance;
    }

    public void UpdateMoney(float amount)
    {
        currentMoney += amount;
        moneyDisplay.text = $"${currentMoney}";
    }
}
