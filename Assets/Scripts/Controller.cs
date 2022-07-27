using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Static variables")]
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
    private new Rigidbody2D rigidbody;


    public float angularVelocity;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
            rigidbody.AddForce(force * Time.deltaTime * ropeLengthVec.normalized - sparrowRatio * force * Time.deltaTime * ropeLengthVec, ForceMode2D.Force);


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
}
