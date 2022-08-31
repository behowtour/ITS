using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPointAccelerate : Anchor
{
    public float forceAccelerate;

    public override void OnCollision(Collider2D collision)
    {

    }

    public override void OnRelease()
    {

    }

    public override void OnTap()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {         
            Vector2 vectorDirection = this.transform.position - collision.transform.position;
            if (vectorDirection.y > 0)
            {
                SetTriggerParameter();
                Vector2 vectorForceAccelerate = new Vector2(forceAccelerate, forceAccelerate);
                Rigidbody2D rigidbody;
                rigidbody = collision.transform.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(vectorDirection.normalized * vectorForceAccelerate, ForceMode2D.Impulse);
            }                   
        }
    }

    //���� ����� ���� ������� ����� � ����� �������� �������, �� ������ ��������
    public void SetTriggerParameter()
    {
        Animator animator = transform.GetComponent<Animator>();
        animator.SetTrigger("Trigger");
    }
}
