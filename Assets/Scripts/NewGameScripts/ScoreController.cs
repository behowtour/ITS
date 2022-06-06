using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [Header("Static variables")]
    public GameObject scoreCount;

    private Score score;
    private ScorePanel scorePanel;

    private void Awake()
    {
        this.score = new Score();
        this.scorePanel = new ScorePanel(this.score, scoreCount.GetComponent<Text>());
    }

    public void AddScore(object sender, int amount)
    {
        score.AddScore(sender, amount);
    }
}
