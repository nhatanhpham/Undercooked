using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stove : Countertop
{
    private bool locked = false;
    public override void OnDrop(PointerEventData pointerEventData)
    {
        if(locked)
        {
            return;
        }

        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if (card == null)
        {
            return;
        }

        Ingredient newIngredient = card.GetIngredient();

        if(newIngredient.IsCookable())
        {
            card.SetCountertop(this);
            SetIngredient(newIngredient);
        }
    } 

    public void SetLockedState(bool locked)
    {
        this.locked = locked;
    }
}
