using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;

    private Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}