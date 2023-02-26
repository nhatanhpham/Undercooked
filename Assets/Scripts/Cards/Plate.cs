using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Plate : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        platable = true;
        cookable = false;
        cuttable = false;
    }

    public override void Evolve()
    {

    }

    public override void Combine(Card toCombine)
    {
        Ingredient ingToCombine = toCombine.GetIngredient();
        if(ingToCombine.IsPlatable())
        {
            ingToCombine.PlateIng();
            toCombine.SetStartPosition(transform.position);
            Destroy(gameObject);
        }
    }

    public override void PlateIng()
    {
        Destroy(gameObject);
    }
}
