using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Undercooked/Recipe", fileName = "New Recipe")]
[System.Serializable]
public class Recipe : ScriptableObject
{
    [SerializeField]
    private string recipeName;
    [SerializeField]
    private List<GameObject> ingredients = new();
    private Dictionary<string, int> ingredientCount = new();
    [SerializeField]
    private Sprite finishedDish;
    [SerializeField]
    private GameObject order;
    [SerializeField]
    private float maxProfit;

    private void OnEnable()
    {
        foreach(GameObject ingredient in ingredients)
        {
            string ingredientName = ingredient.name;
            if(ingredientCount.ContainsKey(ingredientName))
            {
                ingredientCount[ingredientName]++;
            }
            else
            {
                ingredientCount.Add(ingredientName, 1);
            }
        }
    }

    public string GetName()
    {
        return recipeName;
    }

    public List<GameObject> GetIngredients()
    {
        return ingredients;
    }

    public Dictionary<string, int> GetIngredientsAsDict()
    {
        return ingredientCount;
    }

    public Sprite GetFinishedDish()
    {
        return finishedDish;
    }

    public GameObject GetOrder()
    {
        return order;
    }

    public float GetMaxProfit()
    {
        return maxProfit;
    }

    public bool CheckMatch(Dictionary<string, int> combinedIngredients)
    {
        foreach(var keyValuePair in combinedIngredients)
        {
            if(!ingredientCount.ContainsKey(keyValuePair.Key))
            {
                return false;
            }

            if (ingredientCount[keyValuePair.Key] != keyValuePair.Value)
            {
                return false;
            }
        }
        return true;
    }
}
