using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointUpLift : Anchor
{
    public float delayTime;
    public float upDistance;
    public AudioClip audioClip_UpLift;
    public float startspeed;

    private float speed;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool isMoving;
    private float timeStart;
    private Vector3 positionCurrent, positionStart;
    private Vector2 positionCurrent2, positionStart2;
    private Animator animator;

    public override void OnCollision(Collider2D collision)
    {
    }

    public override void OnRelease()
    {
        mainController.isLiftUp = false;
        isMoving = false;
        mainController.ResetDistanceJoint();
        
        animator.SetTrigger("TriggerFade");
        //Destroy(this.transform.gameObject);
    }

    public override void OnTap()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(audioClip_UpLift);
        animator.enabled = true;
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
        animator = transform.GetComponent<Animator>();
        animator.enabled = false;
        rb = this.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 5);
        isMoving = false;
        if (startspeed == 0)
        {
            startspeed = 7;
        }
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
            //rb.position = (1 - u) * positionStart2 + u * new Vector2(positionStart2.x, positionStart2.y + upDistance);
            speed = Mathf.Pow(startspeed, 1 + (u * 1.5f));
            rb.velocity = Vector2.up * speed;
        }
    }

 
    IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(delayTime);
        OnMouseUp();
    }
}
