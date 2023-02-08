using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stove: MonoBehaviour, IDropHandler
{
    private Card[] cards;
    public int numOfIngredients;
    public void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if (card != null)
        {
            for (int i = 0; i < numOfIngredients; i++)
            {
                if (cards[i] == null)
                {
                    card.SetStartPosition(transform.position);
                    cards[i] = card;
                }
            }
        }
    }
}
