using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class StoveManager : MonoBehaviour
{
    public IngredientSlot[] ingredientSlots;

    public List<Card> itemList;
    public string[] recipes;
    public Card[] recipeResults;

    private bool successfulOutcome;

    public void ButtonClicked()
    {
        CheckForCreatedRecipes();
    }

    void CheckForCreatedRecipes()
    {
        successfulOutcome = false;
        string currentRecipe = "";
        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            itemList[i] = ingredientSlots[i].ingredient;
        }
        itemList = itemList.OrderBy(x => x.name).ToList();

        foreach(Card ingredient in itemList)
        {
            if (itemList != null)
            {
                currentRecipe += ingredient;
            }
            else
            {
                currentRecipe += "null";
            }
        }

        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i] == currentRecipe)
            {
                ingredientSlots[1].ingredient = recipeResults[i];
                successfulOutcome = true;
            }
        }
        ingredientSlots[0].ingredient = null;
        ingredientSlots[2].ingredient = null;
    }
}
