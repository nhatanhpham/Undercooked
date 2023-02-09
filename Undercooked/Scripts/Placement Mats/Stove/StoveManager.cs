using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class StoveManager : MonoBehaviour
{
    //These are the 3 areas that you can put ingredients in
    [SerializeField]
    private List<Stove> ingredientSlots;
    [SerializeField]
    private GameObject canvas;

    private Dictionary<string, int> ingredients = new();
    private int indexNotNull = -1;

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
