using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public SpringJoint2D spring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))

        {
          
            //Debug.Log("Mouse down");

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                spring.enabled = true;
                //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);

                spring.connectedAnchor = new Vector2(hit.transform.position.x, hit.transform.position.y);
                //Debug.Log("Touched");

            }
        }
        else
        {
            spring.enabled = false;
          
        }
    }
}
