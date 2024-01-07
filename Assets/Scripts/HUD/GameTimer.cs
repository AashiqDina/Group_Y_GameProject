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
        completedTimeText.text = elapsedTime.ToString("F2");
        RecordTime();
    }

    private void RecordTime()
    {
        //string timeString = "Completed in: " + elapsedTime.ToString("F2") + " seconds";
        //completedTimeText.text = timeString; // Existing UI
        endScreenTimeText.text = completedTimeText.text;
    }

}


