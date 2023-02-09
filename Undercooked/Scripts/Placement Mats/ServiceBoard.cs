using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ServiceBoard : Countertop
{
    public void Serve()
    {
        if(ingredient != null)
        {
            RecipeManager.GetInstance().CheckOrderMatch(ingredient.GetCurrentImage());
            DestroyIngredient();
        }
    }
}