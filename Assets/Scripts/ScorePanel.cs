using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel
{
    private Score score;
    private Text textScoreValue;
    

    public ScorePanel(Score score, Text textScoreValue)
    {
        this.score = score;
        this.textScoreValue = textScoreValue;
        this.score.OnScoreChangedEvent += OnScoreChanged;
    }

    private void OnScoreChanged(object sender, int oldScoreValue, int newScoreValue)
    {
        textScoreValue.text = string.Format("Score: {0}", newScoreValue);
    }
}
