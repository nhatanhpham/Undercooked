using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakDeck : ScriptableObject
{
    public List<Steak> steakDeck = new List<Steak>();
    public int x = 0;
    //public GameObject Steak;
    void Start()
    {
        AddSteak();
    }

    // Update is called once per frame
    void Update()
    {
        if(steakDeck.Count < 1)
        {
            AddSteak();
        }
    }
    public void AddSteak()
    {
        steakDeck.Add(new Steak());
    }
    public void RemoveSteak()
    {
        steakDeck.RemoveAt(0);
        //Instantiate Steak card in Player hand,
        //once hand is established
    }
}
