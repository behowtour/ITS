using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Transform heroTransform;
    public Text scoreText;
    public float timeLeft = 1f;
    public float lastCoordinateY;

    
    void Start()
    {
        GameObject hero = GameObject.Find("Hero");
        heroTransform = hero.transform;
        scoreText.text = "0";
        lastCoordinateY = heroTransform.position.y;
    }

    void Update()
    {
        int coordDiff = (int)(heroTransform.position.y - lastCoordinateY);
        if (coordDiff>0)
        {
            ScoreUp(coordDiff);
            lastCoordinateY = heroTransform.position.y;
        }
    }

    private void ScoreUp(int score)
    {
        int scoreCount;
        scoreCount = int.Parse(scoreText.text) + score;
        scoreText.text = scoreCount.ToString();
    }
}
