using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField]
    protected Image preview;
    [SerializeField]
    protected string ingredientName;

    public Sprite GetCurrentImage() {return preview.sprite;}
    public string GetIngredientName() { return ingredientName; }
    public void SetPreviewSprite(Sprite newSprite) { preview.sprite = newSprite;}

    /*
    Evolve pertains to the stages the ingredient goes through.
    Example for Steak: raw -> chopped -> cooked
    */
    public abstract void Evolve();

    //Combine combines ingredients together, including plates
    public abstract void Combine(Ingredient toCombine);
}
