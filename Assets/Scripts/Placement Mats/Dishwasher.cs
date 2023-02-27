using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dishwasher : Countertop
{
    [SerializeField]
    private LimitedDeck plates;
    public override void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if(card == null)
        {
            return;
        }

        Ingredient plate = card.GetIngredient();
        if(plate.GetIngredientName().Equals("Plate"))
        {
            card.SetCountertop(this);
            ingredient = plate;
        } 
    }

    public void Wash()
    {
        if(ingredient != null && !ingredient.IsPlatable())
        {
            ingredient.Evolve();
        }
    }
}
