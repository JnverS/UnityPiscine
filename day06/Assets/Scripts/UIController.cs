using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image detection;
    public GameObject gameOver;
    public GameObject warningPanel;
    public GameObject missionText;
    public Text warningText;
    public Text instructions;
    private bool startedText;
    private Coroutine _coroutine;
    void Start()
    {
        detection.fillAmount = 0f;
        warningText.text = "";
        StartCoroutine(DisplayText());
    }

    private IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(5f);
        missionText.SetActive(false);
    }

    public void GameMessage(string str)
    {
        gameOver.SetActive(true);
        if (!startedText)
            StartCoroutine(AutoText(str));
    }
    
    public void SetDetectionBar(float detectionLevel)
    {
        detection.fillAmount = detectionLevel;
    }

    public void StartBlinking(bool flag)
    {
        if (flag)
            _coroutine = StartCoroutine(BlinkText());
        else
        {
            StopCoroutine(_coroutine);
            warningText.text = "";
            warningPanel.SetActive(false);
        }
    }

    public void SetInstructions(string str)
    {
        instructions.text = str;
    }
    private IEnumerator AutoText(string str)
    {
        startedText = true;
        string gameOverText = str;
        Text gameOverMessage = gameOver.GetComponent<Text>();
        for (int i = 0; i < gameOverText.Length; i++)
        {
            gameOverMessage.text = gameOverText.Substring(0, i);
            yield return new WaitForSeconds(0.3f);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            warningText.text = "warning";
            warningPanel.SetActive(true);
            yield return new WaitForSeconds(.2f);
            warningText.text = "";
            warningPanel.SetActive(false);
            yield return new WaitForSeconds(.2f);
        }
    }
}
