using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ingredient
{
    /*
    Evolve pertains to the stages the ingredient goes through.
    Example for Steak: raw -> chopped -> cooked
    */
    void Evolve();

    //Combine combines ingredients together, including plates
    void Combine(Ingredient toCombine);
}
