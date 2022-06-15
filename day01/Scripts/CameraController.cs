using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject selectedPlayer;
    public int speed;
    private Vector3 _pos;
    void Start()
    {
    }

    private void Update()
    {

        _pos = selectedPlayer.transform.position;
        Vector3 newPos = new Vector3(_pos.x , _pos.y + 0, -10);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
