using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] private Text lifes;
    [SerializeField] private Text rings;

    private void Start()
    {
        lifes.text = PlayerPrefs.GetInt("LifesSpent").ToString();
        rings.text = PlayerPrefs.GetInt("RingsCollect").ToString();
    }
    
}
