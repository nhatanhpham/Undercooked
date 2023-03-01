using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    [SerializeField]
    private GameObject playerOneCanvas;
    [SerializeField]
    private GameObject playerTwoCanvas;
    [SerializeField]
    private GameObject ordersCanvas;
    [SerializeField]
    private List<GameObject> orderSlots;

    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.GetInstance().SetPlayerCanvas(playerOneCanvas, playerTwoCanvas);
        RecipeManager.GetInstance().AddOrders(ordersCanvas, orderSlots);
    }
}
