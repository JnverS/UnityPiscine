using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject target;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != target.name)
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name != target.name)
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
