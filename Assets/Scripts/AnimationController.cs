using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationController : MonoBehaviour
{

    public float angle;
    public GameObject hero;
    public Vector2 vel;
    public Vector2 velN;
    public Vector3 newRot;
    Rigidbody2D rigid;
    public Vector3 glassesPos;
    public GameObject glasses;
    Animator animator;
    
    void Start()
    {
        rigid = hero.GetComponent<Rigidbody2D>();
        glassesPos = glasses.transform.localPosition;
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {

       



        vel = rigid.velocity.normalized;
        velN = rigid.velocity;
        newRot = Vector3.forward;
        newRot.z = -vel.x * 30;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRot), 0.8f *Time.deltaTime);
        float offset = Mathf.Clamp(velN.y / 10, -1, 1);
        glasses.transform.localPosition = new Vector2(glassesPos.x + offset * -0.3f, glassesPos.y);
        animator.SetFloat("velocity", offset);
      //  float clipLenght=  animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
       // animator.Play("AnimDyn", 0, (offset+1)/2);
       
        animator.speed = 0;
    }
}
