using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class IngredientSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    public GameObject canvas;

    public GameObject ingredient;
    public int index;

    void Start()
    {
        ingredient = null;
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        ingredient = pointerEventData.pointerDrag;
        if (ingredient != null)
        {
            ingredient.GetComponent<Card>().SetStartPosition(transform.position);
            Debug.Log(ingredient.GetComponent<Card>().getName());
        }
    }


    public void NewIngredient(GameObject newIngredient)
    {
        ingredient = GameObject.Instantiate(newIngredient, transform.position, Quaternion.identity, canvas.transform);
    }
}
