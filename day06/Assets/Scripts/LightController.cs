using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // private float rotationLeft = 360;
    // private float rotationSpeed = 30;
    public GameController gameController;
    void Update()
    {
        // float rotation = rotationSpeed * Time.deltaTime;
        // if (rotationLeft > rotation)
        //     rotationLeft -= rotation;
        // else
        // {
        //     rotation = rotationLeft;
        //     rotationLeft = 360;
        // }
        // transform.Rotate(rotation, rotation, rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MainCamera")
            gameController.detected = true;
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "MainCamera")
            gameController.detected = false;
    }
}
