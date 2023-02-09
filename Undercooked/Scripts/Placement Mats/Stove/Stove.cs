using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stove : Countertop
{
    public override void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if (card == null)
        {
            return;
        }

        Ingredient newIngredient = pointerEventData.pointerDrag.GetComponent<Ingredient>();
        if(newIngredient == null)
        {
            return;
        }

        if(newIngredient.IsCookable())
        {
            card.SetStartPosition(transform.position);
            ingredient = newIngredient;
        }
    } 
}
