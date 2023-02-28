using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Countertop : MonoBehaviour, IDropHandler
{
    protected Ingredient ingredient = null;
    public virtual void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if(card != null)
        {
            card.SetCountertop(this);
            SetIngredient(card.GetIngredient());
        }
    }

    public Ingredient GetIngredient() { return ingredient; }

    public void SetIngredient(Ingredient newIngredient) {ingredient = newIngredient; }

    public void RemoveIngredient() {ingredient = null;}

    public void DestroyIngredient() 
    {
        if(ingredient != null)
        {
            Destroy(ingredient.gameObject);
            ingredient = null;
        }
    }
}
