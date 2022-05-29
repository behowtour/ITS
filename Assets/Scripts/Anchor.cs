using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Controller mainController;
    public float impulsePower;

    private void Start()
    {
        mainController = GameObject.Find("Hero").transform.GetComponent<Controller>();
    }


    private void OnMouseDown()
    {
        mainController.hittedAnchor = gameObject;
        mainController.isMouseHoldOnAnchor = true;
        mainController.power = impulsePower;
    }

    private void OnMouseUp()
    {
        mainController.hittedAnchor = null;
        mainController.isMouseHoldOnAnchor = false;
    }
}
