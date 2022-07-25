using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Controller mainController;
    public float impulsePower;
    public GameObject particleObjectPrefab;
    public GameObject particleObject;
    public ParticleSystem particles;
    public AnimationController2 animController;


    private void Start()
    {
        mainController = GameObject.Find("Hero").transform.GetComponent<Controller>();
        animController = GameObject.FindGameObjectWithTag("Body").GetComponent<AnimationController2>();
     
        
    }


    private void OnMouseDown()
    {
        mainController.hittedAnchor = gameObject;
        mainController.isMouseHoldOnAnchor = true;
        mainController.power = impulsePower;
        particleObject =  Instantiate(particleObjectPrefab, transform.position, transform.rotation);
        particles = particleObject.GetComponent<ParticleSystem>();
        particles.Play();
        animController.animator.SetBool("isThrowing", true);
    }

    private void OnMouseUp()
    {
        mainController.hittedAnchor = null;
        mainController.isMouseHoldOnAnchor = false;
        StopParticlesAndDestroy();
        animController.animator.SetBool("isThrowing", false);
    }

    public void StopParticlesAndDestroy()
    {
        
        
            particles?.Stop();
            Destroy(particleObject, 0.5f);
        
    }
}
