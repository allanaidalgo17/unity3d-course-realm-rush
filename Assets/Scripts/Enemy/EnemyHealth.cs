using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;

    private int currentHealth;
    private Enemy enemy;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
