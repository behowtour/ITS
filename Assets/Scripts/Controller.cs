using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Static variables")]
    public bool isMouseHoldOnAnchor;
    public float force;

    [Header("Dynamic variables")]
    public GameObject hittedAnchor, lastHittedAnchor;
    public Vector2 ropeLengthVec;
    public float power;
    

    private new Rigidbody2D rigidbody;
    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void HitPoint()
    {
        if (hittedAnchor)
        {
            ropeLengthVec = hittedAnchor.transform.position - transform.position;
            lastHittedAnchor = hittedAnchor;
        }
        if (Input.GetMouseButton(0) && isMouseHoldOnAnchor)
        {
            rigidbody.AddForce(force * Time.deltaTime * ropeLengthVec.normalized - 0.05f * force * Time.deltaTime * ropeLengthVec, ForceMode2D.Force);
        }
        if (ropeLengthVec.y < 0) 
        { 
            ropeLengthVec = Vector2.zero; isMouseHoldOnAnchor = false;
            hittedAnchor = null;
        }
        if (!hittedAnchor && lastHittedAnchor && lastHittedAnchor.tag.Contains("OrangeLeaf"))
        {
            Destroy(lastHittedAnchor);
        }
    }
}
