using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Countertop : MonoBehaviour, IDropHandler
{
    protected Ingredient ingredient = null;
    public void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if(card != null)
        {
            card.SetStartPosition(transform.position);
            ingredient = pointerEventData.pointerDrag.GetComponent<Ingredient>();
        }
    }

    public Ingredient GetIngredient() { return ingredient; }

    public void DestroyIngredient() 
    {
        if(ingredient != null)
        {
            Destroy(ingredient.gameObject);
            ingredient = null;
        }
    }
}
