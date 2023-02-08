using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField]
    protected Image preview;
    public Sprite GetCurrentImage()
    {
        return preview.sprite;
    }

    /*
    Evolve pertains to the stages the ingredient goes through.
    Example for Steak: raw -> chopped -> cooked
    */
    public abstract void Evolve();

    //Combine combines ingredients together, including plates
    public abstract void Combine(Ingredient toCombine);
}
