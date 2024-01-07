using UnityEngine;
using UnityEngine.InputSystem;

public class StartOrRestartGame : MonoBehaviour
{
    public GameObject startScreenPanel; // Assign this in the Inspector
    public InputAction startAction;
    private bool isGameStarted = false;

    private void OnEnable()
    {
        startAction.Enable();
        startAction.performed += OnStartPerformed;
    }

    private void OnDisable()
    {
        startAction.Disable();
        startAction.performed -= OnStartPerformed;
    }

    private void Start()
    {
        // Ensure the game starts with the start screen visible
        startScreenPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    private void OnStartPerformed(InputAction.CallbackContext context)
    {
        if (!isGameStarted)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isGameStarted = true;
        startScreenPanel.SetActive(false); // Hide the start screen
        Time.timeScale = 1f; // Resume the game
    }
}

