using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript_ex00 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isActive;
    public string key;
    public GameObject mainCamera;
    private float _moveInput;
    private Rigidbody2D _rb;
    private bool _isGround;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (isActive)
        {
            _moveInput = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(_moveInput * speed, _rb.velocity.y);
        }
    }

    private void SelectPlayer()
    {
        if (Input.GetKey(key))
        {
            isActive = true;
            mainCamera.GetComponent<CameraController>().selectedPlayer = gameObject;
        }
        else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
            isActive = false;
    }
    private void Update()
    {
        SelectPlayer();
        if (isActive)
        {
            if (Input.GetKey(KeyCode.Space) && _isGround)
            {
                _rb.AddForce(Vector2.up * jumpForce);
                _isGround = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }
}
