using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointUpLift : Anchor
{
    public float delayTime;
    public float upDistance;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool isMoving;
    private float timeStart;
    private Vector3 positionCurrent, positionStart;
    private Vector2 positionCurrent2, positionStart2;

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
        timeStart = Time.time;
        positionStart = this.transform.position;
        positionStart2 = rb.position;
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
        if (isMoving)
        {
            float u = (Time.time - timeStart) / delayTime;
            u = Mathf.Pow(u, 2f);
            if (u >= 1)
            {
                isMoving = false;
            }
            //this.transform.position = (1 - u) * positionStart + u * (new Vector3(positionStart.x, positionStart.y + 5, positionStart.z));
            rb.position = (1 - u) * positionStart2 + u * new Vector2(positionStart2.x, positionStart2.y + upDistance);
        }

    }

    private void FixedUpdate()
    {
        //if (isMoving)
        //{
        //    rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        //}
    }

    IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(delayTime);
        OnMouseUp();
    }
}
