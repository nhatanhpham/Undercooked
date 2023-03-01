using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    [SerializeField]
    private GameObject ordersCanvas;
    [SerializeField]
    private List<GameObject> orderSlots;

    // Start is called before the first frame update
    void Start()
    {
        RecipeManager.GetInstance().AddOrders(ordersCanvas, orderSlots);
    }
}
