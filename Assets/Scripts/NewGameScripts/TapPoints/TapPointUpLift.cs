using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointUpLift : Anchor
{
    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool isMoving;

    public override void OnCollision(Collider2D collision)
    {
    }

    public override void OnRelease()
    {
        mainController.isLiftUp = false;
        isMoving = false;
        mainController.ResetDistanceJoint();
        Destroy(this.transform.gameObject);
    }

    public override void OnTap()
    {
        mainController.isLiftUp = true;
        isMoving = true;
        mainController.SetConnectedRB(rb);
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 5);
        isMoving = false;
    }
    private void Update()
    {
        if (isMoving)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
}
