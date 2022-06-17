using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject sureMenu;
    public Texture2D cursor;
    private gameManager manager;
    private bool isPaused;
    private bool isPausedMenu;
    void Start()
    {
        manager = gameManager.GetComponent<gameManager>();
        isPaused = false;
        pauseMenu.SetActive(false);
        sureMenu.SetActive(false);
        isPausedMenu = false;
        if (cursor)
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void PlaySpeedX1()
    {
        manager.changeSpeed(1);
        isPaused = false;
    }

    public void PlaySpeedX2()
    {
       manager.changeSpeed(2);
        isPaused = false;
    }

    public void PlaySpeedX4()
    {
        manager.changeSpeed(4);
        isPaused = false;
    }
    public void Pause()
    {
        if (!isPaused)
        {
            manager.pause(true);
            isPaused = true;
        }
    }

    public void Return()
    {
        sureMenu.SetActive(false);
        pauseMenu.SetActive(false);
        manager.pause(false);
        isPausedMenu = false;
    }

    public void SureMenu()
    {
        pauseMenu.SetActive(false);
        sureMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Hide()
    {
        pauseMenu.SetActive(false);
        sureMenu.SetActive(false);
        isPausedMenu = false;
        manager.pause(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPausedMenu)
            {
                pauseMenu.SetActive(true);
                sureMenu.SetActive(false);
                isPausedMenu = true;
                manager.pause(true);
            }
            else
                Hide();
        }
    }
}

