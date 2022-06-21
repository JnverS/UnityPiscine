using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityController : MonoBehaviour
{
    public GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MainCamera")
            gameController.cctvDetected = true;
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "MainCamera")
            gameController.cctvDetected= false;
    }
}
