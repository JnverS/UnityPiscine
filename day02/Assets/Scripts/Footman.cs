using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Footman : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    public float speed = 1f;
    private Animator _animator;
    private bool _lookingRight = true;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (_isMoving)
        {
            Move();
        }
    }

    private void SetTargetPosition()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPosition.z = transform.position.z;

        _isMoving = true;

    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        _animator.Play("runRight");
        
        if (_targetPosition.x > transform.position.x && !_lookingRight) Flip();
        if (_targetPosition.x < transform.position.x && _lookingRight) Flip();
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
    }

    private void Flip()
    {
        _lookingRight = !_lookingRight;
        transform.Rotate(0,100f,0);
    }
}
