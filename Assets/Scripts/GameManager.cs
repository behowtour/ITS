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
    public float lastCoordinateY;

    private Transform heroTransform;
    private LeafGenerator point;
    private bool onPlay;
    private CameraFollow cameraFollow;
    private Controller controller;

    void Start()
    {
        hero = GameObject.Find("Hero");
        cameraFollow = transform.gameObject.GetComponent<CameraFollow>();
        controller = hero.transform.gameObject.GetComponent<Controller>();
        point = GetComponent<LeafGenerator>();
        heroTransform = hero.transform;
        scoreText.text = "0";
        lastCoordinateY = heroTransform.position.y;
        restartButtonObject.SetActive(false);

        onPlay = true; //«аменить на FALSE когда будет переход из меню
    }

    void Update()
    {
        if (onPlay)
        {
            point.GenerateNextPoint();
            int coordDiff = (int)(heroTransform.position.y - lastCoordinateY);
            if (coordDiff > 0)
            {
                ScoreUp(coordDiff);
                lastCoordinateY = heroTransform.position.y;
            }
            cameraFollow.Follow();
            controller.HitPoint();
            if (point.CheckGameOver())
            {
                restartButtonObject.SetActive(true);
                onPlay = false;
                Destroy(hero);
            }
        }
    }

    private void ScoreUp(int score)
    {
        int scoreCount;
        scoreCount = int.Parse(scoreText.text) + score;
        scoreText.text = scoreCount.ToString();
    }
}
