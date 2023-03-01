using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class StoveManager : MonoBehaviour
{
    private enum State
    {
        Waiting, Cooking, Cooked
    }
    private State currentState = State.Waiting;

    //These are the 3 areas that you can put ingredients in
    [SerializeField]
    private List<Stove> ingredientSlots;
    [SerializeField]
    private GameObject canvas;

    private Dictionary<string, int> ingredients = new();
    private int indexNotNull = -1;

    public void Update()
    {
        if(!HasIngredients() && currentState == State.Cooked)
        {
            ToggleLockIngredientSlots(false);
            currentState = State.Waiting;
        }
    }

    private bool HasIngredients()
    {
        foreach(Stove slot in ingredientSlots)
        {
            if(slot.GetIngredient() != null)
            {
                return true;
            }
        }
        return false;
    }

    public void StartCooking()
    {
        currentState = State.Cooking;
        ToggleLockIngredientSlots(true);
    }

    private void ToggleLockIngredientSlots(bool locked)
    {
        foreach(Stove slot in ingredientSlots)
        {
            slot.SetLockedState(locked);
        }
    }

    public void CheckForCreatedRecipes()
    {
        for(int i = 0; i < ingredientSlots.Count; i++)
        {
            Ingredient ingredient = ingredientSlots[i].GetIngredient();
            if (ingredient != null)
            {
                indexNotNull = i;
                AddToDictionary(ingredient.GetIngredientName());
            }
        }

        if(RecipeManager.GetInstance().CheckRecipeMatch(ingredients))
        {
            CombineIngredients();
        }
        else
        {
            indexNotNull = -1;
        }
        ClearIngredientSlots(indexNotNull);
        ResetValues();
        currentState = State.Cooked;
    }

    private void AddToDictionary(string ingredientName)
    {
        if(ingredients.ContainsKey(ingredientName))
        {
            ingredients[ingredientName]++;
        }
        else
        {
            ingredients.Add(ingredientName, 1);
        }
    }

    private void CombineIngredients()
    {
        ingredientSlots[indexNotNull].GetIngredient().Evolve();
    }

    private void ClearIngredientSlots(int save)
    {
        for(int i = 0; i < ingredientSlots.Count; i++)
        {
            if(i != save)
            {
                ingredientSlots[i].DestroyIngredient();
            }
        }
    }

    private void ResetValues()
    {
        ingredients.Clear();
        indexNotNull = -1;
    }
}
