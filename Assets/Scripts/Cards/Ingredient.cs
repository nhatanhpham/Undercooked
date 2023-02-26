using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField]
    protected Image preview;
    [SerializeField]
    protected GameObject platePreview;
    [SerializeField]
    protected string ingredientName;
    [SerializeField]
    protected Card card;

    protected bool plated = false;
    protected bool platable = false;
    protected bool cookable;
    protected bool cuttable;

    public Card GetCard() { return card; }
    public Sprite GetCurrentImage() {return preview.sprite;}
    public string GetIngredientName() { return ingredientName; }
    public bool IsPlated() { return plated; }
    public bool IsPlatable() { return platable;}
    public bool IsCookable() { return cookable;}
    public bool IsCuttable() { return cuttable;}
    public void SetPreviewSprite(Sprite newSprite) { preview.sprite = newSprite;}

    /*
    Evolve pertains to the stages the ingredient goes through.
    Example for Steak: raw -> chopped -> cooked
    */
    public abstract void Evolve();

    //Combine combines cards together, including plates
    public virtual void Combine(Ingredient toCombine)
    {
        if(toCombine.GetIngredientName().Equals("Plate") && toCombine.IsPlatable() && IsPlatable())
        {
            PlateIng();
            toCombine.PlateIng();
        }
    }

    public virtual void PlateIng()
    {
        platePreview.SetActive(true);
        plated = true;
    }
}
