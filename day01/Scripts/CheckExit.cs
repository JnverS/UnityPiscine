using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExit : MonoBehaviour
{
    public GameObject target;
    public bool exit;
    void Start()
    {
        exit = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == target.name)
            exit = true;
    }    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == target.name)
            exit = false;
    }
}
