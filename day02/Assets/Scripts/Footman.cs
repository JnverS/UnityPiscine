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
    [SerializeField] private AudioSource run;
    [SerializeField] public GameObject unitsController;
    private UnitsController _controller;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = unitsController.GetComponent<UnitsController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_controller.units.Contains(this.gameObject))
            {
                SetTargetPosition();
                run.Play();
            }
        }

        if (_isMoving && Input.GetKey(KeyCode.LeftControl) == false)
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
        
        _animator.SetFloat("x", _targetPosition.x - transform.position.x);
        _animator.SetFloat("y", _targetPosition.y - transform.position.y);
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
    }
}
