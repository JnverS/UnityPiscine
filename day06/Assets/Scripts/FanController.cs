using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MainCamera")
            gameController.invis = true;
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "MainCamera")
            gameController.invis= false;
    }
}
