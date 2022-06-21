using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject lights;
    public GameObject fan;
    public UIController ui;
    public bool detected;
    public bool cctvDetected;
    public float detectionLevel;
    private bool warning;
    public bool gameOver;
    public bool invis = false;
    void Update()
    {
        if (!gameOver)
            CalculateDetectionLvl();
        if (detectionLevel >= 1f)
            GameStatus("Mission has failed");
        if (Input.GetKey(KeyCode.E))
            fan.SetActive(true);
    }

    private void CalculateDetectionLvl()
    {
        float calcDetect = -0.001f;
        if (cctvDetected)
        {
            if (invis)
                calcDetect += 0.001f;
            else
                calcDetect += 0.005f;
        }

        if (detected)
            calcDetect += 0.005f;
        detectionLevel += calcDetect;
        if (detectionLevel < 0f || detectionLevel > 1f)
            detectionLevel = (detectionLevel < 0f ? 0f : 1f);
        ui.SetDetectionBar(detectionLevel);
        if (detectionLevel >= 0.75 && !warning)
            BlinkText(true);
        if (detectionLevel < 0.75 && warning)
            BlinkText(false);
    }

    private void BlinkText(bool flag)
    {
        ui.StartBlinking(flag);
        warning = flag;
    }

    private void GameStatus(string str)
    {
        gameOver = true;
        ui.GameMessage(str);
    }
}
