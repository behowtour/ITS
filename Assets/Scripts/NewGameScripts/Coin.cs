using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [Header("Static variables")]
    public GameObject coinsCount;
    public ScoreController scoreController;
    public int scoreCost;

    private Bank bank;
    private CoinsPanel coinsPanel;


    private void Awake()
    {
        this.bank = new Bank();
        this.coinsPanel = new CoinsPanel(this.bank, coinsCount.GetComponent<Text>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            this.bank.AddCoins(this, 1);
            this.scoreController.AddScore(this, scoreCost);
            Destroy(this.transform.gameObject);
        }
    }
}
