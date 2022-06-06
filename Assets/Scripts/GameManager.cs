using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Static variables")]
    public GameObject restartButtonObject;
    public GameObject hero;
    public float wallsOffset;

    [Header("Dynamic variables")]
    //public Text scoreText;
    public ScoreController scoreController;
    public float lastCoordinateY, leftBorderWorld, rightBorderWorld, screenHeightWorld;

    private Transform heroTransform;
    private LeafGenerator pointsGenerator;
    private bool onPlay;
    private CameraFollow cameraFollow;  
    private Camera cam;
    private Controller controller;
    private GameOver gameOver;
    

    void Start()
    {
        Application.targetFrameRate = 60;
        hero = GameObject.Find("Hero");
        cameraFollow = transform.gameObject.GetComponent<CameraFollow>();
        controller = hero.transform.gameObject.GetComponent<Controller>();
        pointsGenerator = GetComponent<LeafGenerator>();
        cam = GetComponent<Camera>();
        gameOver = GetComponent<GameOver>();
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftBorderWorld = botLeftWorld.x;
        rightBorderWorld = topRightWorld.x;
        screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
        heroTransform = hero.transform;
        //scoreText.text = "0";
        lastCoordinateY = heroTransform.position.y;
        restartButtonObject.SetActive(false);
        EdgeCollider2D[] edgeColliders2D = transform.gameObject.GetComponents<EdgeCollider2D>();
        SetUpWalls(edgeColliders2D, leftBorderWorld - wallsOffset, rightBorderWorld + wallsOffset, screenHeightWorld * 2, (-1) * screenHeightWorld);
        pointsGenerator.screenHeightWorld = screenHeightWorld;
        pointsGenerator.leftBorderWorld = leftBorderWorld;
        pointsGenerator.rightBorderWorld = rightBorderWorld;
        pointsGenerator.GenerateFirstPoint();
        ChangeDifficulty(0);
        onPlay = true;
    }

    void Update()
    {
        if (onPlay)
        {
            pointsGenerator.GenerateNextPoint();
            int coordDiff = (int)(heroTransform.position.y - lastCoordinateY);
            if (coordDiff > 0)
            {
                //ScoreUp(coordDiff);
                scoreController.AddScore(this, 1);
                lastCoordinateY = heroTransform.position.y;
            }
            cameraFollow.Follow();
            controller.HitPoint();

            onPlay = !(gameOver.CheckGameOver(transform.position.y, pointsGenerator.lastLeaf.transform.position.y, screenHeightWorld)
                || gameOver.CheckGameOver(controller.hittedAnchor));
            if (!onPlay)
            {
                restartButtonObject.SetActive(true);
                Destroy(hero);
            }
        }
    }



    //private void ScoreUp(int score)
    //{
    //    int scoreCount;
    //    scoreCount = int.Parse(scoreText.text) + score;
    //    scoreText.text = scoreCount.ToString();
    //    ChangeDifficulty(scoreCount);
    //}

    private void SetUpWalls(EdgeCollider2D[] edgeColliders2D, float left, float right, float up, float down) 
    {
        List<Vector2> pointsLeftWall = new List<Vector2>();
        pointsLeftWall.Add(new Vector2(left, up));
        pointsLeftWall.Add(new Vector2(left, down));

        List<Vector2> pointsRightWall = new List<Vector2>();
        pointsRightWall.Add(new Vector2(right, up));
        pointsRightWall.Add(new Vector2(right, down));

        edgeColliders2D[0].SetPoints(pointsLeftWall);
        edgeColliders2D[1].SetPoints(pointsRightWall);
    }

    private void ChangeDifficulty(int scoreCount)
    {
        if (scoreCount>200)
        {
            pointsGenerator.greenLeafChance     = 35000;
            pointsGenerator.orangeLeafChance    = 35000;
            pointsGenerator.redLeafChance       = 30000;
        }
        else if (scoreCount>100)
        {
            pointsGenerator.greenLeafChance     = 55000;
            pointsGenerator.orangeLeafChance    = 30000;
            pointsGenerator.redLeafChance       = 15000;
        }
        else
        {
            pointsGenerator.greenLeafChance     = 80000;
            pointsGenerator.orangeLeafChance    = 15000;
            pointsGenerator.redLeafChance       = 5000;
        }
    }
}
