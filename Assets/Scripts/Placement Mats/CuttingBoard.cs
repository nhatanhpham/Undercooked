using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : Countertop
{

    public AudioSource cutting;

    public void Cut()
    {
        if(ingredient.IsCuttable())
        {
            cutting.Play();
            ingredient.Evolve();
        }
    }
}
