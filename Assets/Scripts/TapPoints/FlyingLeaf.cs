using UnityEngine;
using System;

public class FlyingLeaf : MonoBehaviour
{
    public float MoveTime;

    private float InitialPosY;
    private float UpdateTime;
    private Vector2 RandomPos;

    private Vector2 GenerateRandom(float PosY)
    {
        System.Random rnd = new System.Random();
        float rndX = rnd.Next(-30, 30);
        float rndY = rnd.Next(-20, 20);
        rndX = rndX * 0.1f;
        rndY = rndY * 0.1f + PosY;

        return new Vector2(rndX,rndY);
    }

    private void OnEnable()
    {
        UpdateTime = 0f;
    }
    void Start()
    {
        InitialPosY = transform.position.y;
        RandomPos = GenerateRandom(InitialPosY);
    }
    private void FixedUpdate()
    {
        if ((Vector2)transform.position != RandomPos) //Math.Abs(transform.position.x - RandomPos.x) >= 0.2f &&
                                                      //Math.Abs(transform.position.y - RandomPos.y) >= 0.2f)
        {
            UpdateTime += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, RandomPos, UpdateTime / MoveTime);
        }
        else
        {
            UpdateTime = 0f;
            RandomPos = GenerateRandom(InitialPosY);
        }

    }
}
