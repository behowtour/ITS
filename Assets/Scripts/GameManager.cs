using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject restartButtonObject;
    public GameObject hero;
    public Text scoreText;
    public float timeLeft = 1f;
    public float lastCoordinateY;

    private Transform heroTransform;
    private LeafGenerator point;


    void Start()
    {
        hero = GameObject.Find("Hero");
        point = GetComponent<LeafGenerator>();
        heroTransform = hero.transform;
        scoreText.text = "0";
        lastCoordinateY = heroTransform.position.y;
        restartButtonObject.SetActive(false);
    }

    void Update()
    {
        if (point.CheckGameOver())
        {
            restartButtonObject.SetActive(true);
            Destroy(hero);
            
        }
        int coordDiff = (int)(heroTransform.position.y - lastCoordinateY);
        if (coordDiff>0)
        {
            ScoreUp(coordDiff);
            lastCoordinateY = heroTransform.position.y;
        }
        
        
        Debug.Log( point.CheckGameOver());
    }

    private void ScoreUp(int score)
    {
        int scoreCount;
        scoreCount = int.Parse(scoreText.text) + score;
        scoreText.text = scoreCount.ToString();
    }
}
