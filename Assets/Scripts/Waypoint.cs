using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get => isPlaceable; private set => isPlaceable = value; }

    private void OnMouseDown()
    {
        if (IsPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            IsPlaceable = !isPlaced;
        }
    }
}
