using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float leftBorderWorld, rightBorderWorld, screenHeightWorld;
    public GameObject restartButtonObject;
    public GameObject hero;
    public Text scoreText;
    public float lastCoordinateY;

    private Transform heroTransform;
    private LeafGenerator point;
    private bool onPlay;
    private CameraFollow cameraFollow;  
    private Camera cam;
    private Controller controller;
    private GameOver gameOver;
    

    void Start()
    {
        hero = GameObject.Find("Hero");
        cameraFollow = transform.gameObject.GetComponent<CameraFollow>();
        controller = hero.transform.gameObject.GetComponent<Controller>();
        point = GetComponent<LeafGenerator>();
        cam = GetComponent<Camera>();
        gameOver = GetComponent<GameOver>();
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftBorderWorld = botLeftWorld.x;
        rightBorderWorld = topRightWorld.x;
        screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
        heroTransform = hero.transform;
        scoreText.text = "0";
        lastCoordinateY = heroTransform.position.y;
        restartButtonObject.SetActive(false);
        EdgeCollider2D[] edgeColliders2D = transform.gameObject.GetComponents<EdgeCollider2D>();
        SetUpWalls(edgeColliders2D, leftBorderWorld - 0.5f, rightBorderWorld + 0.5f, screenHeightWorld * 2, (-1) * screenHeightWorld);




        point.GenerateFirstPoint();
        point.screenHeightWorld = screenHeightWorld;
        point.leftBorderWorld = leftBorderWorld;
        point.rightBorderWorld = rightBorderWorld;
        onPlay = true;
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
            if (gameOver.CheckGameOver(transform.position.y, point.lastLeaf.transform.position.y,screenHeightWorld))
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

    private void SetUpWalls(EdgeCollider2D[] edgeColliders2D, float left, float right, float up, float down) 
    {
        List<Vector2> pointsLeftWall = new List<Vector2>();
        pointsLeftWall.Add(new Vector2(left, up));
        pointsLeftWall.Add(new Vector2(left, down));

        List<Vector2> pointsRightWall = new List<Vector2>();
        pointsRightWall.Add(new Vector2(right, up));
        pointsRightWall.Add(new Vector2(right, down));

        //EdgeCollider2D[] edgeCollider2D = gameObject.GetComponents<EdgeCollider2D>();
        edgeColliders2D[0].SetPoints(pointsLeftWall);
        edgeColliders2D[1].SetPoints(pointsRightWall);
    }
}
