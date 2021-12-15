using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get => isPlaceable; private set => isPlaceable = value; }

    private void OnMouseDown()
    {
        if (IsPlaceable)
        {
            Vector3 towerPosition = transform.position;
            Quaternion towerRotation = Quaternion.identity;

            GameObject tower = Instantiate(towerPrefab, towerPosition, towerRotation);

            IsPlaceable = false;
        }
    }
}
