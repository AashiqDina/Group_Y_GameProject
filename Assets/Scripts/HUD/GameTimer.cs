/*using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float startTime;
    private bool timerActive = false;
    public float elapsedTime;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (timerActive)
        {
            elapsedTime = Time.time - startTime;
        }
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
        RecordTime();
    }

    private void RecordTime()
    {
        // Implement logic to record the time
        // Example: Debug.Log("Elapsed Time: " + elapsedTime);
    }
}*/

using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class GameTimer : MonoBehaviour
{
    private float startTime;
    private bool timerActive = false;
    public float elapsedTime;
    public Text timerText; // Reference to the UI Text component
    public Text completedTimeText;

    void Start()
    {
        StartTimer();
    }

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
        RecordTime();
    }

    private void RecordTime()
{
    completedTimeText.text = "Completed in: " + elapsedTime.ToString("F2") + " seconds";
    Debug.Log("Level completed in: " + elapsedTime.ToString("F2") + " seconds");
}

}


