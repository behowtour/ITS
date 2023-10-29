using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Manual variables")]
    public bool isMouseHoldOnAnchor;
    public float force;
    public float sparrowRatio;
    public float maxDownSpeedY;
    public AnimationController2 animationController;

    [Header("Dynamic variables")]
    public GameObject hittedAnchor, lastHittedAnchor;
    public Vector2 ropeLengthVec;
    public float power;
    public float xSpeed, ySpeed, velMagnSpeed;
    public bool isLiftUp;

    public delegate void ControllerHandler();
    public event ControllerHandler OnReleaseAnchor;

    private new Rigidbody2D rigidbody;
   
    private Vector3 heroStartOffset;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isLiftUp = false;
    }

    private void FixedUpdate()
    {
        xSpeed = rigidbody.velocity.x;
        ySpeed = rigidbody.velocity.y;
        velMagnSpeed = rigidbody.velocity.magnitude;
        if (rigidbody.velocity.y <= (-1)*maxDownSpeedY)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, (-1) * maxDownSpeedY);
        }
        
    }

    public void HitPoint()
    {
        if (Input.GetMouseButton(0) && isMouseHoldOnAnchor && hittedAnchor )
        {
            ropeLengthVec = hittedAnchor.transform.position - transform.position;
            lastHittedAnchor = hittedAnchor;
            if (isLiftUp)
            {
               // transform.position = hittedAnchor.transform.position - heroStartOffset;
            }
            else
            {
                rigidbody.AddForce(force * Time.deltaTime * ropeLengthVec.normalized - sparrowRatio * force * Time.fixedDeltaTime * ropeLengthVec, ForceMode2D.Force);
            }
        }
        if (ropeLengthVec.y < 0)
        {
            ropeLengthVec = Vector2.zero;
            ReleaseAnchor();
            //isMouseHoldOnAnchor = false;
        }
    }

    public void ReleaseAnchor()
    {
        isMouseHoldOnAnchor = false;
        this.OnReleaseAnchor?.Invoke();
    }

    public void GetStartHeroOffset()
    {
        heroStartOffset = hittedAnchor.transform.position - transform.position;
    }

   
    
}
