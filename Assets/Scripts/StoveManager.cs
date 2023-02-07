using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class StoveManager : MonoBehaviour
{
    //These are the 3 areas that you can put ingredients in
    public IngredientSlot[] ingredientSlots;

    //This is tied in with ingredientSlots (basically a list of strings of ingredient names)
    public List<string> itemList;

    //Create a list of recipes
    //Please Uppercase the first letter of each ingredient
    //Some examples are:
    //Steak + Steak + Steak should have the string SteakSteakSteak
    //Banana + Banana Leaves + Banana Peel = BananaBananaLeavesBananaPeel
    public string[] recipes;

    //Creates a list of results from the recipes above
    //Drag in prefab that you want corresponding to the recipe index
    //An example is:
    //recipes[0] = BaconEggSausage then recipeResults[0] should have the prefab "AmericanClassicBreakfast"
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

        if (recipeOutcome != null)
        {
            ingredientSlots[1].NewIngredient(recipeOutcome);
            print(ingredientSlots[1].ingredient.GetComponent<Card>().getName());
        }
    }
}
