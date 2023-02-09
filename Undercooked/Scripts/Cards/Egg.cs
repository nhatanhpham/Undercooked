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

    // Start is called before the first frame update
    void Start()
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

    public override void Combine(Ingredient toCombine)
    {

    }
}
