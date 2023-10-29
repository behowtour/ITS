using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public delegate void ScoreHandler(object sender, int oldScoreValue, int newScoreValue);
    public event ScoreHandler OnScoreChangedEvent;
    
    public int score { get; private set; }

    public void AddScore(object sender, int amount)
    {
        var oldScoreValue = this.score;
        this.score += amount;
        this.OnScoreChangedEvent?.Invoke(sender, oldScoreValue, this.score);
    }
}
