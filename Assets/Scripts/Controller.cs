using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Static variables")]
    public bool isMouseHoldOnAnchor;

    [Header("Dynamic variables")]
    public GameObject hittedAnchor;
    public Vector2 ropeLengthVec;
   
    private new Rigidbody2D rigidbody;
    public float power;
    public float force;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void HitPoint()
    {
        if (hittedAnchor)
        {
            ropeLengthVec = hittedAnchor.transform.position - transform.position;
        }

        if (Input.GetMouseButton(0) && isMouseHoldOnAnchor)
        {
            rigidbody.AddForce(force * Time.deltaTime * ropeLengthVec.normalized, ForceMode2D.Force);
        }
    }
}
