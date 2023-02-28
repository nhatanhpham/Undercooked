using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    [SerializeField]
    private TextMeshProUGUI moneyDisplay;
    private float currentMoney;
    public enum Player
    {
        One, Two
    }
    private Player currentPlayer = Player.One;
    [SerializeField]
    private GameObject playerOneCanvas;
    [SerializeField]
    private GameObject playerTwoCanvas;
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

    public static GameStateManager GetInstance()
    {
        return _instance;
    }

    public void UpdateMoney(float amount)
    {
        currentMoney += amount;
        moneyDisplay.text = $"${currentMoney}";
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void SwitchPlayer()
    {
        if(currentPlayer == Player.One)
        {
            currentPlayer = Player.Two;
            playerOneCanvas.SetActive(false);
            playerTwoCanvas.SetActive(true);
        }
        else if(currentPlayer == Player.Two)
        {
            currentPlayer = Player.One;
            playerOneCanvas.SetActive(true);
            playerTwoCanvas.SetActive(false);
        }
    }
}
