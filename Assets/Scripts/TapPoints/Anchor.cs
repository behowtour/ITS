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

    [Header("Dynamic variables")]
    public GameObject particleObject;
    public ParticleSystem particles;
    public AnimationController2 animController;

public Controller mainController;
    protected bool used, inUse;
    protected AudioSource audioSource;

    private void Start()
    {
        mainController = GameObject.Find("Hero").transform.GetComponent<Controller>();
        animController = GameObject.FindGameObjectWithTag("Body").GetComponent<AnimationController2>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        used = false;
        inUse = false; 
    }

    private void OnMouseDown()
    {
        if (!used && !inUse)
        {
         
            inUse = true;
            mainController.hittedAnchor = gameObject;
            particleObject = Instantiate(particleObjectPrefab, transform.position, transform.rotation);
            HittedAnchorReAttached();
            mainController.isMouseHoldOnAnchor = true;
            mainController.power = impulsePower;
            mainController.GetStartHeroOffset();
            audioSource.PlayOneShot(audioClip_Tap);
            particles = particleObject.GetComponent<ParticleSystem>();
            particles.Play();
            animController.animator.SetBool("isThrowing", true);
            this.mainController.OnReleaseAnchor += ReleasePoint;
            OnTap();
        }
    }

    protected void OnMouseUp()
    {
        mainController.ReleaseAnchor();
        //ReleasePoint();
    }

    public void ReleasePoint()
    {
        this.mainController.OnReleaseAnchor -= ReleasePoint;
        inUse = false;
        UsePoint();
        mainController.hittedAnchor = null;
        mainController.isMouseHoldOnAnchor = false;
        StopParticlesAndDestroy();
        if (audioClip_Release)
        {
            audioSource.PlayOneShot(audioClip_Release);
        }
        else
        {
            Debug.Log(this.transform.gameObject.name);
        }
        
        OnRelease();
        if (animController.animator!=null)
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
    public abstract void HittedAnchorReAttached();
    public abstract void OnTap();
    public abstract void OnRelease();
    public abstract void OnCollision(Collider2D collision);
}
