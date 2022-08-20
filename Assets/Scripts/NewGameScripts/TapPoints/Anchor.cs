using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Anchor : MonoBehaviour
{
    [Header("Manual variables")]
    public float impulsePower;
    public GameObject particleObjectPrefab;

    [Header("Dynamic variables")]
    public GameObject particleObject;
    public ParticleSystem particles;
    public AnimationController2 animController;
    

    protected Controller mainController;

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
        mainController.GetStartHeroOffset();
        OnTap();
        particleObject =  Instantiate(particleObjectPrefab, transform.position, transform.rotation);
        particles = particleObject.GetComponent<ParticleSystem>();
        particles.Play();
        animController.animator.SetBool("isThrowing", true);
    }

    protected void OnMouseUp()
    {
        mainController.hittedAnchor = null;
        mainController.isMouseHoldOnAnchor = false;
        StopParticlesAndDestroy();
        OnRelease();
        animController.animator.SetBool("isThrowing", false);
    }

    public void StopParticlesAndDestroy()
    {
            particles?.Stop();
            Destroy(particleObject, 0.5f);        
    }

    public abstract void OnTap();
    public abstract void OnRelease();
    public abstract void OnCollision(Collider2D collision);
}
