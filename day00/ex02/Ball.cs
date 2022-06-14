using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Club		club;
    public GameObject hole;
    public GameObject borderBottom;
    public GameObject borderTop;

    private float	_pow;
    private bool	_dirUp;
    private bool	_moving;
    private int		_score;
    public bool		isInHole;

    void Start () {
        _pow = 0f;
        _dirUp = true;
        _moving = false;
        _score = -15;
        isInHole = false;
    }
	
    void InHole() {
        if (hole.transform.position.y - transform.position.y <= 0.7f &&
            hole.transform.position.y - transform.position.y >= -0.7f && _pow < 0.03f)
        {
            Debug.Log("Score: " + _score);
            transform.position = new Vector3(0, hole.transform.position.y, 0f);
            club.SetPos(0f);
            isInHole = true;
        }
    }

    void Update ()
    {
        if (isInHole) return;
        if (_pow > 0)
        {
            if (_dirUp == true)
            {
                if (transform.position.y >= borderTop.transform.position.y)
                {
                    transform.Translate(Vector3.down * _pow);
                    _dirUp = false;
                }
                else
                    transform.Translate(Vector3.up * _pow);
            }
            else
            {
                if (transform.position.y <= borderBottom.transform.position.y)
                {
                    transform.Translate(Vector3.up * _pow);
                    _dirUp = true;
                }
                else
                {
                    transform.Translate(Vector3.down * _pow);
                }
            }
            InHole();
            _pow -= 0.005f;
        }
        else
        {
            _dirUp = true;
            if (_moving == true)
            {
                _moving = false;
                _score += 5;
                Debug.Log("Score: " + _score);
                InHole();
                if (!isInHole)
                    club.SetPos(transform.position.y);
            }
        }
    }

    public void SetPow (float pow) {
        if (_moving == false)
        {
            this._pow = pow;
            _moving = true;
        }
    }
}
