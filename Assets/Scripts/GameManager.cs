using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameMode
    {
        onPlay, onTransition, onPause, onMenu

    }

    public static GameMode gameMode;
    [Header("Static variables")]
    public GameObject restartButtonObject;
    public GameObject hero;
    public GameObject cameraMain;
    public GameObject rope;
    public float camPositionOffset;
    public float wallsOffset;


    [Header("Dynamic variables")]
    public ScoreController scoreController;
    public float lastCoordinateY;

    [SerializeField]
    private float heroSpeed;

    [SerializeField]
    private PointsGeneratorPool pointsGeneratorPool;

    [SerializeField] private PointsGeneratorModern pointsGeneratorModern;

    private Transform heroTransform;
    private Rigidbody2D heroRigidbody2D;
    private PointsGenerator pointsGenerator;
    private EnemiesGenerator enemiesGenerator;
    public bool onPlay;
    private GoFollow goFollow;  
    private Camera cam;
    private Controller controller;
    private RopeBridge ropeBridge;
    

    void Start()
    {
       Application.targetFrameRate = 60;
        hero = GameObject.Find("Hero");
        heroRigidbody2D = hero.GetComponent<Rigidbody2D>();
        this.goFollow = new GoFollow();
        controller = hero.transform.gameObject.GetComponent<Controller>();
        ropeBridge = rope.transform.gameObject.GetComponent<RopeBridge>();
        // pointsGenerator = GetComponent<PointsGenerator>();
        enemiesGenerator = GetComponent<EnemiesGenerator>();
        cam = GetComponent<Camera>();
        Vector3 botLeftWorld = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        ConstantSettings.leftBorderWorld = botLeftWorld.x;
        ConstantSettings.rightBorderWorld = topRightWorld.x;
        ConstantSettings.screenHeightWorld = Mathf.Abs(botLeftWorld.y) + Mathf.Abs(topRightWorld.y);
        heroTransform = hero.transform;
        lastCoordinateY = heroTransform.position.y;
        restartButtonObject.SetActive(false);
        EdgeCollider2D[] edgeColliders2D = transform.gameObject.GetComponents<EdgeCollider2D>();
        SetUpWalls(edgeColliders2D, ConstantSettings.leftBorderWorld - wallsOffset, ConstantSettings.rightBorderWorld + wallsOffset, ConstantSettings.screenHeightWorld * 2, (-1) * ConstantSettings.screenHeightWorld);
        // pointsGenerator.GenerateFirstPoint();
        pointsGeneratorPool.GenerateFirstPoint();
        //pointsGeneratorModern.GenerateFirstPoint();
        ChangeDifficulty(0);
        GameOver.isGameOver = false;
        onPlay = true;
    }


    private void FixedUpdate()
    {
        if (onPlay)
        {
            controller.HitPoint();
            ropeBridge.RopeUpdate();
        }
    }

    void Update()
    {
        if (onPlay)
        {
            heroSpeed = heroRigidbody2D.velocity.y;
            // pointsGenerator.GenerateNextPoint();
            // pointsGenerator.DestroyOldPoint();
            pointsGeneratorPool.GenerateNextPoint();
            // pointsGeneratorModern.GenerateNextPoint();
            enemiesGenerator.GenerateEnemy(heroSpeed);
            int coordDiff = (int)(heroTransform.position.y - lastCoordinateY);
            if (coordDiff > 0)
            {
                lastCoordinateY = heroTransform.position.y;
            }
            GameOver.CheckGameOver(hero.transform.position.y, transform.position.y, ConstantSettings.screenHeightWorld);
            onPlay = !GameOver.isGameOver;
            if (!onPlay)
            {
                restartButtonObject.SetActive(true);
                Destroy(hero);
            }
        }
    }

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
        
    }


}
