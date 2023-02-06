using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        }
    }
}
