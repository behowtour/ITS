using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationController2 : MonoBehaviour
{

  
    public Vector2 vel;
    Rigidbody2D rigid;
   public Animator animator;
    public bool isThrowing = false;
   
    
    void Start()
    {
        rigid = transform.parent.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
      
        float velY = rigid.velocity.y;



     
        animator.SetFloat("Velocity", velY);
       
    }
}
