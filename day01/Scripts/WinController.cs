using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public GameObject redExit;
    public GameObject yellowExit;
    public GameObject blueExit;
    private bool win;
    void Start()
    {
        win = false;
    }

   
    void Update()
    {
        if (!win)
        {
            if (redExit.GetComponent<CheckExit>().exit && yellowExit.GetComponent<CheckExit>().exit &&
                blueExit.GetComponent<CheckExit>().exit)
            {
                win = true;
                Debug.Log("You Win!");
                if (SceneManager.GetActiveScene().buildIndex == 0)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
}
