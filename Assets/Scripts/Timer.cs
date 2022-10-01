using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerStop;
    [SerializeField] private TextMeshProUGUI timerText;
    private float sceneTimer = 10.0f;
    private bool isTimerActive = false;

    private void Start()
    {
        setTimer();
    }
    private void Update()
    {
        if (!isTimerActive) return;

        sceneTimer -= Time.deltaTime;

        if (sceneTimer > 0)
        {
            timerText.text = sceneTimer.ToString("0.00");
            if (sceneTimer < 3)
            {
                timerText.color = Color.red;
            }
        }
        else
        {
            isTimerActive = false;
            timerText.text = "0.00";
            timerText.color = Color.red;
            OnTimerStop?.Invoke();
        }
    }

    public void setTimer()
    {
        isTimerActive = true;
        sceneTimer = 10.0f;
    }
}
