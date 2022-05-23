using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_spring_mod : MonoBehaviour
{

    public SpringJoint2D spring;
    public Rigidbody2D heroRb;
    public Vector3 v3Velocity;
    public float speedHero,prevSpeedHero;
    public bool needSpring;
    private RaycastHit2D hit;

    void Start()
    {
        heroRb = GetComponent<Rigidbody2D>();
        v3Velocity = heroRb.velocity;
        prevSpeedHero = 0;
        speedHero = 0;
        needSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        //if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse down");
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (needSpring)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "RedLeaf")
                    {
                        Destroy(this.gameObject);
                        Debug.Log("GAME OVER");
                    }
                    else
                    {
                        v3Velocity = heroRb.velocity;
                        speedHero = v3Velocity.magnitude;
                        if (speedHero>0 && speedHero < prevSpeedHero)
                        {
                            spring.enabled = false;
                            needSpring = false;
                            prevSpeedHero = 0;
                        }
                        else
                        {
                            spring.enabled = true;
                            prevSpeedHero = speedHero;
                            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);

                            spring.connectedAnchor = new Vector2(hit.transform.position.x, hit.transform.position.y);
                            Debug.Log("Touched");
                        }

                        
                    }

                }
            }
            else
            {
                spring.enabled = false;
            }

        }
        
        if (Input.GetMouseButtonUp(0))
        {
            needSpring = true;
            spring.enabled = false;
            prevSpeedHero = 0;
        }
    }
}
