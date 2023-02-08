using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private GameObject ingredient;
    [SerializeField]
    private GameObject canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject newIngredient = Instantiate(ingredient, transform.position, Quaternion.identity);
        newIngredient.transform.SetParent(canvas.transform, false);
        eventData.pointerDrag = newIngredient;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
