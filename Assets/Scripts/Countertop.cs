using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Countertop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData pointerEventData)
    {
        Card card = pointerEventData.pointerDrag.GetComponent<Card>();
        if(card != null)
        {
            card.SetStartPosition(transform.position);
        }
    }
}
