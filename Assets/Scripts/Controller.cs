using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public SpringJoint2D spring;
    public bool isMouseHoldOnAnchor;
    public GameObject hittedAnchor;

    public Vector2 ropeLengthVec;
   
    

    private new Rigidbody2D rigidbody;
    public float power;
    public float force;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HitPoint()
    {
        if (hittedAnchor)
        {
            ropeLengthVec = hittedAnchor.transform.position - transform.position;
        }
        //ropeLengthVec = hittedAnchor.transform.position - transform.position;

        if (Input.GetMouseButton(0) && isMouseHoldOnAnchor)

        {
            rigidbody.AddForce(force * Time.deltaTime * ropeLengthVec.normalized, ForceMode2D.Force);

        }
    }
}
