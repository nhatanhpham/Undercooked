using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class StoveManager : MonoBehaviour
{
    public IngredientSlot[] ingredientSlots;

    public List<string> itemList;
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
            if (ingredientSlots[i].ingredient != null)
            { itemList[i] = ingredientSlots[i].ingredient.GetComponent<Card>().getName(); }
            else
            { itemList[i] = "null"; }
        }
        itemList = itemList.OrderBy(x => x).ToList();

        foreach(string ingredient in itemList)
        {
            currentRecipe += ingredient;
        }

        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i] == currentRecipe)
            {
                recipeOutcome = recipeResults[i];
                print("Crafted");
            }
        }

        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            if (ingredientSlots[i] != null)
            {
                Destroy(ingredientSlots[i].ingredient);
                ingredientSlots[i].ingredient = null;
            }
        }

        /*if (recipeOutcome != null)
        {
            ingredientSlots[1].NewIngredient(recipeOutcome);
        }*/
    }
}
