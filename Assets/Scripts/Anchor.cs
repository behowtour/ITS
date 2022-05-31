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

    private void Start()
    {
        mainController = GameObject.Find("Hero").transform.GetComponent<Controller>();
     
        
    }


    private void OnMouseDown()
    {
        mainController.hittedAnchor = gameObject;
        mainController.isMouseHoldOnAnchor = true;
        mainController.power = impulsePower;
        particleObject =  Instantiate(particleObjectPrefab, transform.position, transform.rotation);
        particles = particleObject.GetComponent<ParticleSystem>();
        particles.Play();
    }

    private void OnMouseUp()
    {
        mainController.hittedAnchor = null;
        mainController.isMouseHoldOnAnchor = false;
        StopParticlesAndDestroy();
    }

    public void StopParticlesAndDestroy()
    {
        
        
            particles?.Stop();
            Destroy(particleObject, 0.5f);
        
    }
}
