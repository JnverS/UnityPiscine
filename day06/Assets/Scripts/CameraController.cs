using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class CameraController : MonoBehaviour
{
    public float speed = 2.5f;
    private float mouseX = 15f;
    private float mouseY = 15f;

    private Rigidbody rb;

    private Camera _camera;
    public GameController gameController;
    private float pitch = 0f;
    private float yaw = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        KeyMove();
        MouseMove();
    }

    private void KeyMove()
    {
        if (Input.GetKey(KeyCode.W))
            transform.localPosition += transform.forward * speed * Time.deltaTime;        
        if (Input.GetKey(KeyCode.S))
            transform.localPosition += -transform.forward * speed * Time.deltaTime;        
        if (Input.GetKey(KeyCode.D))
            transform.localPosition += transform.right * speed * Time.deltaTime;        
        if (Input.GetKey(KeyCode.A))
            transform.localPosition += -transform.right * speed * Time.deltaTime;
    }

    private void MouseMove()
    {
        // return;
        float tmp = pitch - (mouseY * Input.GetAxis("Mouse Y"));
        if (tmp >= -30f && tmp <= 30f)
            pitch = tmp;
        yaw += mouseX * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw+90, 0);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (gameController.cctvDetected)
            gameController.detectionLevel -= 0.05f;
    }
}
