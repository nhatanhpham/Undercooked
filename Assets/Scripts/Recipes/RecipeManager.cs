using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager _instance;

    [SerializeField]
    private List<Recipe> recipes;
    private List<Recipe> ordersRecipes = new();
    private List<GameObject> orders = new();

    [SerializeField]
    private GameObject ordersCanvas;
    [SerializeField]
    private RectTransform rectOrdersCanvas;
    [SerializeField]
    private RectTransform rectOrder;
    [SerializeField]
    private float whitespaceOffset;
    private Vector3 orderSpawnOffset = Vector3.zero;
    private float startingSpawn;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            recipes = Resources.LoadAll<Recipe>("Recipes").ToList();
            startingSpawn = -rectOrdersCanvas.rect.width / 2 + rectOrder.rect.width / 2;
            orderSpawnOffset.x += startingSpawn;
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
        AddOrder();
        AddOrder();
        AddOrder();
    }

    private void Update()
    {
    }

    public void AddOrder()
    {
        Recipe randomRecipe = recipes[Random.Range(0, recipes.Count())];
        ordersRecipes.Add(randomRecipe);
        orders.Add(Instantiate(randomRecipe.GetOrder(), GetSpawnPosition(), Quaternion.identity, ordersCanvas.transform));
        IncrementOffset();
    }

    private Vector3 GetSpawnPosition()
    {
        return ordersCanvas.transform.position + orderSpawnOffset;
    }

    private void ResetOffset()
    {
        orderSpawnOffset.x = startingSpawn;
    }

    private void IncrementOffset()
    {
        orderSpawnOffset.x += rectOrder.rect.width + whitespaceOffset;
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
            ordersRecipes.Remove(orderToRemove);
        }
    }

    public Sprite CheckRecipeMatch(Dictionary<string, int> combinedIngredients)
    {
        Sprite cookedDish = null;
        foreach(Recipe recipe in recipes)
        {
            if(recipe.CheckMatch(combinedIngredients))
            {
                cookedDish = recipe.GetFinishedDish();
                break;
            }
        }
        return cookedDish;
    }

    private void RemoveOrder(GameObject order)
    {
        Destroy(order);
        ResetOffset();
        for(int i = 1; i < orders.Count; i++)
        {
            orders[i].transform.position = GetSpawnPosition();
            IncrementOffset();
        }
    }
}
