using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LimitedDeck : Deck
{
    [SerializeField]
    private int maxAmount;
    private int currentAmount;

    public void Awake()
    {
        currentAmount = maxAmount;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if(currentAmount > 0)
        {
            base.OnBeginDrag(eventData);
            currentAmount--;
            if(currentAmount == 0)
            {
                ToggleVisibility(false);
            }
        }
    }

    public void AddCard()
    {
        if(currentAmount == 0)
        {
            ToggleVisibility(true);
        }
        currentAmount++;
    }

    private void ToggleVisibility(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
