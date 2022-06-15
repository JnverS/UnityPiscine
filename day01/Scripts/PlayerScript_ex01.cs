using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript_ex01 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isActive;
    public string key;
    public GameObject mainCamera;
    private float _moveInput;
    private int _numCollision;
    private Rigidbody2D _rb;
    private bool _isGround;
    private bool _jumpControl;
    private int _jumpIteration = 0;
    public int jumpValueIteration = 60;
    
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
            _rb.mass = 1f;
            mainCamera.GetComponent<CameraController>().selectedPlayer = gameObject;
        }
        else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
        {
            isActive = false;
            _rb.mass = 50000f;
        }
    }
    private void Update()
    {
        SelectPlayer();
        Jump();

    }


    private void Jump()
    {
        if (isActive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (_isGround) _jumpControl = true;
            }
            else _jumpControl = false;

            if (_jumpControl)
            {
                if (_jumpIteration++ < jumpValueIteration)
                {
                    _rb.AddForce(Vector2.up * jumpForce / _jumpIteration);
                    _isGround = false;
                }
            }
            else _jumpIteration = 0;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            _numCollision++;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
            _numCollision--;
        if (_numCollision == 0)
            _isGround = false;
    }
}
