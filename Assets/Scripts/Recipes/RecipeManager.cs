using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager _instance;

    private List<Recipe> recipes;
    private List<Recipe> ordersRecipes = new();
    private List<GameObject> orders = new();

    [SerializeField]
    private GameObject ordersCanvas;
    [SerializeField]
    private List<GameObject> orderSlots;
    private int currentSlot;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            recipes = Resources.LoadAll<Recipe>("Recipes").ToList();
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static RecipeManager GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            AddOrder();
        }
    }

    private void Update()
    {
    }

    public void AddOrder()
    {
        Recipe randomRecipe = recipes[Random.Range(0, recipes.Count)];
        ordersRecipes.Add(randomRecipe);
        orders.Add(Instantiate(randomRecipe.GetOrder(), GetSpawnPosition(), Quaternion.identity, ordersCanvas.transform));
        IncrementOffset();
    }

    private Vector3 GetSpawnPosition()
    {
        return orderSlots[currentSlot].transform.position;
    }

    private void ResetOffset()
    {
        currentSlot = 0;
    }

    private void IncrementOffset()
    {
        currentSlot++;
    }

    public void CheckOrderMatch(Sprite potentialOrder)
    {
        Recipe orderToRemove = null;
        for(int i = 0; i < ordersRecipes.Count; i++)
        {
            Recipe recipe = ordersRecipes[i];
            if(recipe.GetFinishedDish() == potentialOrder)
            {
                orderToRemove = recipe;
                RemoveOrder(orders[i]);
                GameStateManager.GetInstance().UpdateMoney(recipe.GetMaxProfit());
                break;
            }
        }
        ordersRecipes.Remove(orderToRemove);
    }

    public bool CheckRecipeMatch(Dictionary<string, int> combinedIngredients)
    {
        foreach(Recipe recipe in recipes)
        {
            if(recipe.CheckMatch(combinedIngredients))
            {
                return true;
            }
        }
        return false;
    }

    private void RemoveOrder(GameObject order)
    {
        orders.Remove(order);
        Destroy(order);
        ResetOffset();
        for(int i = 0; i < orders.Count; i++)
        {
            orders[i].transform.position = GetSpawnPosition();
            IncrementOffset();
        }
    }
}
