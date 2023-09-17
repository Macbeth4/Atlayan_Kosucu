using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney Instance;

    public gameManager gamemanager;

    private const string prefMoney = "prefMoney";

    private void Awake()
    {
        Instance = this;

        gamemanager.para1 = PlayerPrefs.GetInt(prefMoney);
    }
    public bool TryRemoveMoney(int moneyToRemove)
    {
        if (gamemanager.para1 >= moneyToRemove)
        {
            gamemanager.para1 -= moneyToRemove;
            PlayerPrefs.SetInt(prefMoney, gamemanager.para1);
            return true;
        }
        else
        {
            return false;
        }
    }
}
