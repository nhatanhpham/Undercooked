using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishes : MonoBehaviour
{
    [SerializeField]
    private GameObject plate;
    [SerializeField]
    private GameObject canvas;

    public void SpawnDirtyPlate()
    {
        Plate newDirtyPlate = Instantiate(plate, transform.position, Quaternion.identity, canvas.transform).GetComponent<Plate>();
        newDirtyPlate.Evolve();
    }

}
