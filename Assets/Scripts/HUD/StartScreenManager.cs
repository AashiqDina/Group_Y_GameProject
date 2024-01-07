using UnityEngine;
using UnityEngine.InputSystem;

/*public class StartOrRestartGame : MonoBehaviour
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

using UnityEngine;
using UnityEngine.InputSystem;*/
using UnityEngine.UI;

public class StartOrRestartGame : MonoBehaviour
{
    public GameObject startScreenPanel; // Assign this in the Inspector
    public Text difficultyText; // Assign this in the Inspector
    public InputAction startAction;
    public InputAction increaseDifficultyAction;
    public InputAction decreaseDifficultyAction;

    private GameDifficulty currentDifficulty = GameDifficulty.Easy;
    private bool isGameStarted = false;

    private void OnEnable()
    {
        startAction.Enable();
        startAction.performed += OnStartPerformed;

        increaseDifficultyAction.Enable();
        increaseDifficultyAction.performed += OnIncreaseDifficulty;

        decreaseDifficultyAction.Enable();
        decreaseDifficultyAction.performed += OnDecreaseDifficulty;

        UpdateDifficultyText();
    }

    private void OnDisable()
    {
        startAction.Disable();
        startAction.performed -= OnStartPerformed;

        increaseDifficultyAction.Disable();
        increaseDifficultyAction.performed -= OnIncreaseDifficulty;

        decreaseDifficultyAction.Disable();
        decreaseDifficultyAction.performed -= OnDecreaseDifficulty;
    }

    private void Start()
    {
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

    private void OnIncreaseDifficulty(InputAction.CallbackContext context)
    {
        if (currentDifficulty < GameDifficulty.Hard)
        {
            currentDifficulty++;
            UpdateDifficultyText();
        }
    }

    private void OnDecreaseDifficulty(InputAction.CallbackContext context)
    {
        if (currentDifficulty > GameDifficulty.Easy)
        {
            currentDifficulty--;
            UpdateDifficultyText();
        }
    }

    private void UpdateDifficultyText()
    {
        if (difficultyText != null)
        {
            difficultyText.text = "Difficulty: " + currentDifficulty.ToString();
        }
    }

    private void StartGame()
    {
        isGameStarted = true;
        startScreenPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        DifficultyManager.Instance.SetDifficulty(currentDifficulty);
    }
}
