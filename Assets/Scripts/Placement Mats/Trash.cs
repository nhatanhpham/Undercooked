using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Countertop
{
    private void Update()
    {
        DestroyIngredient();
    }
}
