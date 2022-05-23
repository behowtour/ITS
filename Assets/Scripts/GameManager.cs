using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public float timeLeft = 1f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreUp();
    }

    private void scoreUp()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            int scoreCount;
            scoreCount = int.Parse(scoreText.text) + 1;
            scoreText.text = scoreCount.ToString();
            timeLeft = 1;
        }
    }
}
