using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class GameTimer : MonoBehaviour
{
    private float startTime;
    private bool timerActive = false;
    public float elapsedTime;
    public Text timerText; // Reference to the UI Text component
    public Text completedTimeText;
    public Text endScreenTimeText; // Assign this in the Inspector


    void Update()
    {
        if (timerActive)
        {
            elapsedTime = Time.time - startTime;
            UpdateTimerDisplay(); // Update the timer display each frame
        }
    }

    private void UpdateTimerDisplay()
    {
        // Format the time as you desire
        timerText.text = elapsedTime.ToString("F2"); // Formats the float to show 2 decimal places
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        elapsedTime = Time.time - startTime;

        if (completedTimeText != null)
        {
            completedTimeText.text = elapsedTime.ToString("F2");
        }
        else
        {
            Debug.LogWarning("completedTimeText not assigned in GameTimer");
        }

        RecordTime();
    }


    private void RecordTime()
    {
        if (endScreenTimeText != null)
        {
            endScreenTimeText.text = completedTimeText != null ? completedTimeText.text : elapsedTime.ToString("F2");
        }
        else
        {
            Debug.LogWarning("endScreenTimeText not assigned in GameTimer");
        }
    }


}


