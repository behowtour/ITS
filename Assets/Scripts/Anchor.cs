using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    //public SpringJoint2D springJoint2D;
    //public ParticleSystem particle;
    private Controllerv2 mainController;
    public float impulsePower;

    private void Start()
    {
        mainController = GameObject.Find("Hero").transform.GetComponent<Controllerv2>();
    }


    private void OnMouseDown()
    {

        //springJoint2D.connectedAnchor = transform.position;
        mainController.hittedAnchor = gameObject;
        mainController.isMouseHoldOnAnchor = true;
        mainController.power = impulsePower;




    }
    private void OnMouseDrag()
    {
        //particle.Play();
       
    }

    //private void OnMouseUp()
    //{
    //    particle.Stop();
    //    mainController.isMouseHoldOnAnchor = false;
    //}

}
