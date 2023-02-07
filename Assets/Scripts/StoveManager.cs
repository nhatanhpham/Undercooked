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
    public List<GameObject> recipeResults;

    private GameObject recipeOutcome;

    public void ButtonClicked()
    {
        Debug.Log("Button Pressed");
        CheckForCreatedRecipes();
    }

    void CheckForCreatedRecipes()
    {
        recipeOutcome = null;
        string currentRecipe = "";
        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            itemList[i] = ingredientSlots[i].ingredient.GetComponent<Card>();
        }
        itemList = itemList.OrderBy(x => x.getName()).ToList();

        foreach(Card ingredient in itemList)
        {
            if (itemList != null)
            {
                currentRecipe += ingredient.getName();
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
                recipeOutcome = recipeResults[i];
                print("Crafted");
            }
        }
        Destroy(ingredientSlots[0].ingredient);
        ingredientSlots[0] = null;
        Destroy(ingredientSlots[1].ingredient);
        ingredientSlots[1] = null;
        Destroy(ingredientSlots[2].ingredient);
        ingredientSlots[2] = null;

        if (recipeOutcome != null)
        {
            ingredientSlots[1].NewIngredient(recipeOutcome);
        }
    }
}
