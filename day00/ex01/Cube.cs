using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _speed;
    private float _precision;
    public KeyCode key;
    void Start()
    {
        _speed = Random.Range(1f, 10f);
    }

    public void pressCorrectKey()
    {
        _precision = transform.position.y - 5.5f;
        if (_precision < 0)
            _precision *= -1;
        Debug.Log("Precision: " + _precision * 10);
        GameObject.Destroy(this.gameObject);
        
    }    public void pressMissKey()
    {
        Debug.Log("Miss!");
        GameObject.Destroy(this.gameObject);
    }
    void Update()
    {
        transform.Translate(0, -_speed * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.A) && key == KeyCode.A)
            pressCorrectKey();
        else if (Input.GetKeyDown(KeyCode.S) && key == KeyCode.S)            
            pressCorrectKey();
        else if (Input.GetKeyDown(KeyCode.D) && key == KeyCode.D)
            pressCorrectKey();
        else if (transform.position.y <= -3.5)
            pressMissKey();
    }
}
