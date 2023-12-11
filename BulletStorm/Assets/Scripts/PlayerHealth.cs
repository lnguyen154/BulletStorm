using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50f;
    public GameManager gameManager;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health.ToString());
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
