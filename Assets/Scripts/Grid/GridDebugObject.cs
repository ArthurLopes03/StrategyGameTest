using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro tmpro;
    private GridObject gridObject;

    public void SetGridObject (GridObject gridObject)
    {
        this.gridObject = gridObject;

    }

    private void Update()
    {
        tmpro.text = gridObject.ToString();
    }
}
