using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onion : Ingredient
{
    private enum EVOLUTION
    {
        Raw, Cut
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Sprite cutSprite;

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
        if (currentEvolution == EVOLUTION.Raw)
        {
            currentEvolution = EVOLUTION.Cut;
            preview.sprite = cutSprite;
        }
    }

    public override void Combine(Ingredient toCombine)
    {

    }
}
