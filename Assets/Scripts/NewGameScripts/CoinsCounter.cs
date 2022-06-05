using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter
{
    private Bank bank;
    private Text textCoinsCount;
    
    public CoinsCounter(Bank bank, Text textCoinsCount)
    {
        this.bank = bank;
        this.bank.OnCoinsValueChangedEvent += OnCoinsValueChanged;
        this.textCoinsCount = textCoinsCount;
    }

    private void OnCoinsValueChanged(object sender, int oldCoinsValue, int newCoinsValue)
    {
        //здесь выводим значение количества монет
        textCoinsCount.text = string.Format("Coins: {0}", newCoinsValue);
    }

}
