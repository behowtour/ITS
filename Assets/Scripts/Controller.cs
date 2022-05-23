using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public SpringJoint2D spring;
    public bool isMouseHoldOnAnchor;
    public GameObject hittedAnchor;

    public Vector2 ropeLengthVec;
   
    

    private Rigidbody2D rigidbody;
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
        if (hittedAnchor)
        {
            ropeLengthVec = hittedAnchor.transform.position - transform.position;
        }
        //ropeLengthVec = hittedAnchor.transform.position - transform.position;

        if (Input.GetMouseButton(0) && isMouseHoldOnAnchor)

        {
            rigidbody.AddForce(ropeLengthVec.normalized * Time.deltaTime * force, ForceMode2D.Force);

        }
    }
  
}
