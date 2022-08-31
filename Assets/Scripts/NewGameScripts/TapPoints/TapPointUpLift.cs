using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointUpLift : Anchor
{
    public float delayTime;
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
        StartCoroutine(DestroyPoint());
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 5);
        isMoving = false;
    }
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(delayTime);
        OnMouseUp();
    }
}
