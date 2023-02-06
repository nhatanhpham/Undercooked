using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class IngredientSlot : MonoBehaviour, IDropHandler
{
    public Card ingredient;
    public int index;

    public void OnDrop(PointerEventData pointerEventData)
    {
        ingredient = pointerEventData.pointerDrag.GetComponent<Card>();
        if (ingredient != null)
        {
            ingredient.SetStartPosition(transform.position);
            Console.WriteLine(ingredient.getName());
        }
    }
}
