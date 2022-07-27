using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationController : MonoBehaviour
{

    
    public GameObject hero;
    public Vector2 vel;
    public Vector3 newRot;
    Rigidbody2D rigid;
 
    
    void Start()
    {
        rigid = hero.GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        vel = rigid.velocity.normalized;
        newRot = Vector3.forward;
        newRot.z = -vel.x * 30;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRot), 0.8f *Time.deltaTime);
    }
}
