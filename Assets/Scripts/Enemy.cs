using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health = 100;
    public int moneyReward = 50;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Notify the game manager to award money
        GameManager.instance.AddMoney(moneyReward);
        Destroy(gameObject);
    }
}

