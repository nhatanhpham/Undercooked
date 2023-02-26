using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onion : Ingredient
{
    private enum EVOLUTION
    {
        Raw, Cut, Cooked
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Sprite cutSprite;
    [SerializeField]
    private Sprite cookedSprite;

    // Start is called before the first frame update
    void Start()
    {
        cookable = false;
        cuttable = true;
        currentEvolution = EVOLUTION.Raw;
    }

    public override void Evolve()
    {
        if (currentEvolution == EVOLUTION.Raw)
        {
            currentEvolution = EVOLUTION.Cut;
            preview.sprite = cutSprite;
            cuttable = false;
            cookable = true;
        }
        else if(currentEvolution == EVOLUTION.Cut)
        {
            currentEvolution = EVOLUTION.Cooked;
            preview.sprite = cookedSprite;
            cookable = false;
            platable = true;
        }
    }
}
