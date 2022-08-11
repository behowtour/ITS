using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointAccelerate : MonoBehaviour,  ITapPoint
{
    public float forceAccelerate;

    public void OnCollision()
    {

    }

    public void OnRelease()
    {

    }

    public void OnTap()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {         
            Vector2 vectorDirection = this.transform.position - collision.transform.position;
            if (vectorDirection.y > 0)
            {
                Vector2 vectorForceAccelerate = new Vector2(forceAccelerate, forceAccelerate);
                Rigidbody2D rigidbody;
                rigidbody = collision.transform.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(vectorDirection.normalized * vectorForceAccelerate, ForceMode2D.Force);
            }                   
        }
    }
}
