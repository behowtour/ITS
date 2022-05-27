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
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftBorderWorld = botLeftWorld.x;
        rightBorderWorld = topRightWorld.x;
        screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
        heroTransform = hero.transform;
        scoreText.text = "0";
        lastCoordinateY = heroTransform.position.y;
        restartButtonObject.SetActive(false);

        point.GenerateFirstPoint(leftBorderWorld, rightBorderWorld);
        point.screenHeightWorld = screenHeightWorld;
        point.leftBorderWorld = leftBorderWorld;
        point.rightBorderWorld = rightBorderWorld;
        onPlay = true; //�������� �� FALSE ����� ����� ������� �� ����
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
}
