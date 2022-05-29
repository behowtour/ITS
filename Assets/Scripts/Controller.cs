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
            rigidbody.AddForce(ropeLengthVec.normalized * Time.deltaTime * force - ropeLengthVec * Time.deltaTime * force * 0.05f, ForceMode2D.Force);
        }
        if (ropeLengthVec.y < 0) { ropeLengthVec = Vector2.zero; isMouseHoldOnAnchor = false; }

        if (!hittedAnchor && lastHittedAnchor && lastHittedAnchor.tag.Contains("OrangeLeaf"))
        {
            Destroy(lastHittedAnchor);
        }
    }
}
