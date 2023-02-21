using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image preview;

    private Vector3 startPosition;

    void Start()
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

    public void SetStartPosition(Vector2 newPosition)
    {
        startPosition = newPosition;
    }
}

