using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steak : MonoBehaviour, Ingredient
{
    private enum EVOLUTION
    {
        Raw, Chopped, Cooked
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Image preview;
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

    public void Evolve()
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

    public void Combine(Ingredient toCombine)
    {

    }
}
