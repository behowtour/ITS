using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointUpLift : Anchor
{
    public float delayTime;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool isMoving;
    private float timeStart;
    private Vector3 positionCurrent, positionStart;

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
            if (u>=0)
            {
                isMoving = false;
            }
            this.transform.position = (1 - u) * positionStart + u * (new Vector3(positionStart.x, positionStart.y+5, positionStart.z));
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
