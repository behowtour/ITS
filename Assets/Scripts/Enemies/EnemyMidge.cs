using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMidge : Enemy
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigodbody;
    BoxCollider2D myBoxCollider;

    void Start()
    {
        myRigodbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
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

    private bool IsFacingRight()
    {
        return transform.localScale.x < Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collisionCollider)
    {
        Debug.Log("—толкновение со стеной");
        if (collisionCollider.CompareTag("MainCamera"))
        {
            transform.localScale = new Vector2(transform.localScale.x * (-1), transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionCollider)
    {
        Debug.Log("игрок попал в зону мухи");
        if (collisionCollider.transform.gameObject.CompareTag("Player"))
        {
            GameOver.CheckGameOver(this.transform.gameObject.tag);
        }
    }
}
