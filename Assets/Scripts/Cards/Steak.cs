using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steak : Ingredient
{
    private enum EVOLUTION
    {
        Raw, Chopped, Cooked
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Sprite choppedSprite;
    [SerializeField]
    private Sprite cookedSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentEvolution = EVOLUTION.Raw;
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public override void Evolve()
    {
        if(currentEvolution == EVOLUTION.Raw)
        {
            currentEvolution = EVOLUTION.Chopped;
            preview.sprite = choppedSprite;
        }
        else if(currentEvolution == EVOLUTION.Chopped)
        {
            currentEvolution = EVOLUTION.Cooked;
            preview.sprite = cookedSprite;
        }
    }

    public override void Combine(Ingredient toCombine)
    {

    }
}
