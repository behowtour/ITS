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
    //public ITapPoint tapPoint;

    [Header("Dynamic variables")]
    public GameObject hittedAnchor, lastHittedAnchor;
    public Vector2 ropeLengthVec;
    public float power;
    public float xSpeed, ySpeed, velMagnSpeed;
    public bool isLiftUp;

    private new Rigidbody2D rigidbody;
    private DistanceJoint2D distanceJoint2D;
    private Vector3 heroStartOffset;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        distanceJoint2D = GetComponent<DistanceJoint2D>();
        distanceJoint2D.enabled = false;
        isLiftUp = false;
    }

    private void Update()
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
        if (Input.GetMouseButton(0) && isMouseHoldOnAnchor)
        {
            ropeLengthVec = hittedAnchor.transform.position - transform.position;
            lastHittedAnchor = hittedAnchor;
            if (isLiftUp)
            {
               // transform.position = hittedAnchor.transform.position - heroStartOffset;
            }
            else
            {
                rigidbody.AddForce(force * Time.deltaTime * ropeLengthVec.normalized - sparrowRatio * force * Time.deltaTime * ropeLengthVec, ForceMode2D.Force);
            }
        }
        if (ropeLengthVec.y < 0) 
        { 
            ropeLengthVec = Vector2.zero; 
            isMouseHoldOnAnchor = false;
        }
        if (!isMouseHoldOnAnchor && lastHittedAnchor && lastHittedAnchor.tag.Contains("OrangeLeaf"))
        {
            Destroy(lastHittedAnchor);
            lastHittedAnchor.GetComponent<Anchor>().StopParticlesAndDestroy();
        }
    }

    public void GetStartHeroOffset()
    {
        heroStartOffset = hittedAnchor.transform.position - transform.position;
    }

    public void SetConnectedRB(Rigidbody2D rb2d)
    {
        distanceJoint2D.connectedBody = rb2d;
        distanceJoint2D.enabled = true; 
    }
    public void ResetDistanceJoint()
    {
        distanceJoint2D.enabled = false;
        distanceJoint2D.connectedBody = null;
    }
}
