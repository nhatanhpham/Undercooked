using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : Countertop
{
    [SerializeField]
    private GameObject playerOneCards;
    [SerializeField]
    private GameObject playerTwoCards;
    public override void OnDrop(PointerEventData pointerEventData)
    {
        base.OnDrop(pointerEventData);
        ToggleCardVisibility();
        
    }

    public void ToggleCardVisibility()
    {
        if(ingredient == null)
        {
            return;
        }

        GameStateManager.Player currentPlayer = GameStateManager.GetInstance().GetCurrentPlayer();
        if (currentPlayer == GameStateManager.Player.One)
        {
            ingredient.transform.SetParent(playerOneCards.transform);
        }
        else if (currentPlayer == GameStateManager.Player.Two)
        {
            ingredient.transform.SetParent(playerTwoCards.transform);
        }
    }
}
