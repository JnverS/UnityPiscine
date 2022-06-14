using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public Ball			ball;
    public GameObject borderBottom;
		
    private float	_pow;
    private bool	_inUse;
    
    void Start () {
        _pow = 0;
        _inUse = false;
    }
    
    void Update ()
    {
        if (ball.isInHole) return;
        if (Input.GetKey(KeyCode.Space) && transform.position.y > borderBottom.transform.position.y)
        {
            _inUse = true;
            if (_pow < 0.8f)
                _pow += 0.001f;
            transform.Translate(Vector3.down * Time.deltaTime * 2);
        }
        else
        {
            if (_inUse == true)
            {
                _inUse = false;
                transform.position = ball.transform.position;
                ball.SetPow(_pow);
                _pow = 0f;
            }
        }
    }

    public void SetPos(float posY) {
        transform.position = new Vector3(transform.position.x - 0.17f, posY, transform.position.z);
    }
}
