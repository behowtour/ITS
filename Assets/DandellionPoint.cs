using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandellionPoint : Anchor
{
    Animator animator;
    Vector3 correctPos;
    ParticleSystem dandellionParticle;
    DistanceJoint2D distanceJoint2D;
    Rigidbody2D rigid;
    
    public override void OnCollision(Collider2D collision)
    {
        
    }

    public override void OnRelease()
    {
        if (distanceJoint2D!=null)
        distanceJoint2D.enabled = false;
    }

    public override void OnTap()
    {
        animator.SetBool("isUp", true);
        dandellionParticle.Play();
        distanceJoint2D.enabled = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.up*200*Time.deltaTime;
        distanceJoint2D.connectedBody = mainController.transform.GetComponent<Rigidbody2D>();
       

    }

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        dandellionParticle = GetComponent<ParticleSystem>();
        distanceJoint2D = GetComponent<DistanceJoint2D>();
        rigid = GetComponent<Rigidbody2D>();
     
    }


  
   
  
}
