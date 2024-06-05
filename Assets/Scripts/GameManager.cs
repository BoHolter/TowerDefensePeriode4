using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int money;
    public int startmoney = 500;

    private void Start()
    {
        money = startmoney;
    }

    void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Money: " + money);
    }
}

