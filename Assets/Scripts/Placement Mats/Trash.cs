using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : Countertop
{
    public override void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if(card != null && !card.GetIngredient().GetIngredientName().Equals("Plate"))
        {
            Destroy(card.gameObject);
        }
    }
}
