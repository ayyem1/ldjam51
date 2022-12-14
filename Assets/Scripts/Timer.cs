using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerStop;
    [SerializeField] private TextMeshProUGUI timerText;
    private float sceneTimer = 11.0f;
    private bool isTimerActive = false;

    private void Update()
    {
        if (!isTimerActive) return;

        sceneTimer -= Time.deltaTime;

        if (sceneTimer > 0)
        {
            // Adds a 1 second delay
            if(sceneTimer <= 10)
            {
                timerText.text = sceneTimer.ToString("0.00");
                if (sceneTimer < 3)
                {
                    timerText.color = Color.red;
                }
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

    public void SetTimer()
    {
        isTimerActive = true;
        sceneTimer = 11.0f;
        timerText.color = Color.white;
    }
    public void StopTimer()
    {
        isTimerActive = false;
    }
}
