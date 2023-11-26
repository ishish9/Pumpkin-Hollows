using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinCounterText;
    private int CoinAmount;
    //public delegate void OnAddCoin();
    public static event Action OnAddCoin; 
    void Start()
    {
        //addCoinDelegate = AddCoin;
    }

    public void UpdateCoinCounter()
    {
    }

    public void AddCoin()
    {
        CoinAmount += CoinAmount + 1;
        CoinCounterText.text = CoinAmount.ToString("0");
    }
}
