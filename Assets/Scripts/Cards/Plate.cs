using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Plate : Ingredient
{
    private enum EVOLUTION
    {
        Clean, Dirty
    }
    private EVOLUTION currentEvolution;

    [SerializeField]
    private Sprite cleanSprite;
    [SerializeField]
    private Sprite dirtySprite;
    // Start is called before the first frame update
    void Start()
    {
        platable = true;
        cookable = false;
        cuttable = false;
        currentEvolution = EVOLUTION.Clean;
    }

    public override void Evolve()
    {
        if(currentEvolution == EVOLUTION.Clean)
        {
            currentEvolution = EVOLUTION.Dirty;
            preview.sprite = dirtySprite;
            platable = false;
        }
        else if(currentEvolution == EVOLUTION.Dirty)
        {
            currentEvolution = EVOLUTION.Clean;
            preview.sprite = cleanSprite;
            platable = true;
        }
    }

    public override void Combine(Ingredient toCombine)
    {
        if(!toCombine.GetIngredientName().Equals("Plate") && toCombine.IsPlatable() && IsPlatable())
        {
            toCombine.PlateIng();
            toCombine.GetCard().SetCountertop(card.GetCountertop());
            card.GetCountertop().SetIngredient(toCombine);
            Destroy(gameObject);
        }
    }

    public override void PlateIng()
    {
        Destroy(gameObject);
    }
}
