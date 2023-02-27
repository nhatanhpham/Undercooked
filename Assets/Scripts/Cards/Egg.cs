using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : Ingredient
{
    private enum EVOLUTION
    {
        Raw, Cooked
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Sprite cookedSprite; 

    void Awake()
    {
        cuttable = false;
        cookable = true;
        currentEvolution = EVOLUTION.Raw;
    }

    public override void Evolve()
    {
        if (currentEvolution == EVOLUTION.Raw)
        {
            currentEvolution = EVOLUTION.Cooked;
            preview.sprite = cookedSprite;
            cookable = false;
            platable = true;
        }
    }
}
