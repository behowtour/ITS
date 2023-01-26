using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMidge : Enemy
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigodbody;
    BoxCollider2D myBoxCollider;

    void Awake()
    {
        myRigodbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        
        spanwRoll = spawnRate + 1;
        //canSpawn = true;
    }

    void Update()
    {
        if (IsFacingRight())
        {
            myRigodbody.velocity = new Vector2(moveSpeed, 0f);
        }else
        {
            myRigodbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    public override bool IsNeedGenerate(float heroSpeed)
    {
        spanwRoll = spawnRate + 1;
        if (heroSpeed < 4.3 && canSpawn)
        {
            //todo: после каждой проверки отправл€ть ожидать таймер на 5 секунд.
            spanwRoll = Random.Range(0, 100);
            canSpawn = false;
            //Invoke("SetCanSpawn", 3);
        }

        if (heroSpeed > 4.3 && !canSpawn)
        {
            canSpawn = true;
        }
        return spanwRoll < spawnRate;
    }
    // protected bool IsNeedGenerate(float heroSpeed)
    // {
    //     if (heroSpeed < 4.3)
    //     {
    //         spanwRoll = Random.Range(0, 100);
    //     }
    //     return spanwRoll < spawnRate;
    // }

    // void SetCanSpawn()
    // {
    //     canSpawn = true;
    // }
    private bool IsFacingRight()
    {
        return transform.localScale.x < Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collisionCollider)
    {
        // Debug.Log("—толкновение со стеной");
        if (collisionCollider.CompareTag("MainCamera"))
        {
            transform.localScale = new Vector2(transform.localScale.x * (-1), transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionCollider)
    {
        Debug.Log("игрок столкнулс€ с мухой");
        if (collisionCollider.transform.gameObject.CompareTag("Player"))
        {
            GameOver.CheckGameOver(this.transform.gameObject.tag);
        }
    }
}
