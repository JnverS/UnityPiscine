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
        ObjectDetermination();
    }

    private void KeyMove()
    {
        if (Input.GetKey(KeyCode.W))
            Move(Vector3.forward);        
        if (Input.GetKey(KeyCode.S))
            Move(Vector3.back);        
        if (Input.GetKey(KeyCode.D))
            Move(Vector3.right);       
        if (Input.GetKey(KeyCode.A))
            Move(Vector3.left); 
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir * Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, 15.312f, transform.position.z);
    }
    private void MouseMove()
    {
        float tmp = pitch - (mouseY * Input.GetAxis("Mouse Y"));
        if (tmp >= -30f && tmp <= 30f)
            pitch = tmp;
        yaw += mouseX * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw + 90, 0);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (gameController.cctvDetected)
            gameController.detectionLevel -= 0.05f;
    }
    private void ObjectDetermination()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            string hitObject = hit.transform.name;
            float distance = Vector3.Distance(hit.transform.position, transform.position);
            switch (hitObject)
            {
                case "KeyCard":
                    gameController.objectVisible = 1;
                    break;
                case "KeyCardReader":
                    gameController.objectVisible = 2;
                    Debug.Log(gameController.objectVisible);
                    break;
                case "docs":
                    gameController.objectVisible = 3;
                    break;
                default:
                    gameController.objectVisible = -1;
                    break;
            }
            if (distance > 3.7f)
                gameController.objectVisible = -1;
        }
        else
        {
            gameController.objectVisible = -1;
        }
    }
}
