using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GameController : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject door; 
    public GameObject lights;
    public GameObject fan;
    public UIController ui;
    public bool detected;
    public bool cctvDetected;
    public float detectionLevel;
    private bool warning;
    public bool gameOver;
    public bool invis = false;
    public bool card;
    public bool docs;
    public int objectVisible = -1;
    void Update()
    {
        if (!gameOver)
            CalculateDetectionLvl();
        if (detectionLevel >= 1.0f)
            GameStatus("Mission has failed");
        if (docs)
            GameStatus("Mission Completed");
        SetInstructions();
        Debug.Log("GC " + objectVisible);
        if (objectVisible > 0 && Input.GetKeyDown(KeyCode.E))
            Activation(objectVisible);

    }

    private void SetInstructions()
    {
        string instr;
        switch (objectVisible)
        {
            case 1:
                instr = "Press E to pick up";
                break;
            case 2:
                if (card)
                    instr = "Press E to use cardkey";
                else
                    instr = "Need to find a cardkey";
                break;
            case 3:
                instr = "Press E to pick up";
                break;
            default:
                instr = "";
                break;
        }

        StartCoroutine(TextControl(instr));
    }

    private IEnumerator TextControl(string str)
    {
        if (objectVisible > 0)
            ui.instructions.CrossFadeAlpha(1, 2.0f, false);
        else
        {
            ui.instructions.CrossFadeAlpha(0, 2.0f, false);
            yield return new WaitForSeconds(1f);
        }
        ui.SetInstructions(str);
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

    public void Activation(int obj)
    {
        Debug.Log(obj);
        switch (obj)
        {
            case 1:
                card = true;
                Destroy(objects[0]);
                break;
            case 2:
                if (card)
                {
                    card = false;
                    objects[3].SetActive(true);
                    Destroy(door);
                }

                break;
            case 3:
                docs = true;
                Destroy(objects[2]);
                break;
        }
    }
}
