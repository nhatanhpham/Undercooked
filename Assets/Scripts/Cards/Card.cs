using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField]
    private Image preview;
    [SerializeField]
    private Ingredient ingredient;

    private Countertop countertop;
    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        preview.raycastTarget = false;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        preview.raycastTarget = false;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        preview.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out Ingredient toCombine))
        {
            ingredient.Combine(toCombine);
        }
    }

    public void SetCountertop(Countertop countertop)
    {
        this.countertop = countertop;
        startPosition = countertop.transform.position;
    }

    public Countertop GetCountertop()
    {
        return countertop;
    }

    public Ingredient GetIngredient()
    {
        return ingredient;
    }
}

