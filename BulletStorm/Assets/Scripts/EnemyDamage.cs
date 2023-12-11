using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health = 50f;
    public GameManager gameManager;

    public void TakeDamage (float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameManager.EnemyKilled();
        Destroy(gameObject);
    }
}
