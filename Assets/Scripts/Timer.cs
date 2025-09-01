using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int totalTime = 600;
    public static int currentTime = 0;
    public TMP_Text timerText;

    [SerializeField] Canvas loseScreen;

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    void Update()
    {
        if (currentTime <= 0)
        {
            loseScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator StartTimer()
    {
        for (int i = totalTime; i >= 0; i--)
        {
            currentTime = i;
            timerText.text = "Time Remaining: " + currentTime;
            yield return new WaitForSeconds(1f);
        }
    }
}