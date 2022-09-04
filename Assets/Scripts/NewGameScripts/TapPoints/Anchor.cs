using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Anchor : MonoBehaviour
{
    [Header("Manual common variables")]
    public float impulsePower;
    public GameObject particleObjectPrefab;
    public bool reusable;
    public AudioClip audioClip_Tap;
    public AudioClip audioClip_Release;
    public AudioClip audioClip_Collision;
   // public Camera mainCamera;
    

    [Header("Dynamic variables")]
    public GameObject particleObject;
    public ParticleSystem particles;
    public AnimationController2 animController;
    
    

    protected Controller mainController;
    protected bool used;
    protected AudioSource audioSource;

    private void Start()
    {
        mainController = GameObject.Find("Hero").transform.GetComponent<Controller>();
        animController = GameObject.FindGameObjectWithTag("Body").GetComponent<AnimationController2>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        used = false;
         
        
        
    }
    

    private void OnMouseDown()
    {
        if (!used)
        {
            mainController.hittedAnchor = gameObject;
            mainController.isMouseHoldOnAnchor = true;
            mainController.power = impulsePower;
            mainController.GetStartHeroOffset();
            audioSource.PlayOneShot(audioClip_Tap);
            OnTap();
            particleObject = Instantiate(particleObjectPrefab, transform.position, transform.rotation);
            particles = particleObject.GetComponent<ParticleSystem>();
            particles.Play();
            animController.animator.SetBool("isThrowing", true);
        }
        
    }

    protected void OnMouseUp()
    {
        UsePoint();
        mainController.hittedAnchor = null;
        mainController.isMouseHoldOnAnchor = false;
        StopParticlesAndDestroy();
        audioSource.PlayOneShot(audioClip_Release);
        OnRelease();
        animController.animator.SetBool("isThrowing", false);
    }

    public void StopParticlesAndDestroy()
    {
            particles?.Stop();
            Destroy(particleObject, 0.5f);        
    }

    protected void DestroyThisAnchor()
    {
        Destroy(this.transform.gameObject);
    }

    protected void UsePoint()
    {
        if (!reusable)
        {
            used = true;
        }
    }
    public abstract void OnTap();
    public abstract void OnRelease();
    public abstract void OnCollision(Collider2D collision);
}
