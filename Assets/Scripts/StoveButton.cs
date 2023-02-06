using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoveButton : MonoBehaviour
{
    public UnityEvent buttonClick;

    private void Awake()
    {
        if(buttonClick == null) { buttonClick = new UnityEvent(); }
    }

    void OnMouseUp()
    {
        buttonClick.Invoke();
    }
}
