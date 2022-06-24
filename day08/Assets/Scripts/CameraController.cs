using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 _position;
    void Start()
    {
        _position = transform.position - target.transform.position;
    }
    
    void Update()
    {
        transform.position = _position + target.transform.position;
    }
}
