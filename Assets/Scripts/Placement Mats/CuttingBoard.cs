using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : Countertop
{
    public void Cut()
    {
        if(ingredient.IsCuttable())
        {
            ingredient.Evolve();
        }
    }
}
