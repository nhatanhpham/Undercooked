using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onion : MonoBehaviour, Ingredient
{
    private enum EVOLUTION
    {
        Raw, Cut
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Image preview;
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

    public void Evolve()
    {
        if (currentEvolution == EVOLUTION.Raw)
        {
            currentEvolution = EVOLUTION.Cut;
            preview.sprite = cutSprite;
        }
    }

    public void Combine(Ingredient toCombine)
    {

    }
}
