using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Bank bank;
    public GameObject coinsCount;
    private CoinsCounter coinsCounter;

    private void Awake()
    {
        this.bank = new Bank();
        this.coinsCounter = new CoinsCounter(this.bank, coinsCount.GetComponent<Text>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            this.bank.AddCoins(this, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            this.bank.AddCoins(this, 1);
            Destroy(this.transform.gameObject);
        }
    }
}
