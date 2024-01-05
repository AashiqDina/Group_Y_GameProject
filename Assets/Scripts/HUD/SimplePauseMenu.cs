using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // Required for scene management

public class SimplePauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private PlayerInput playerInput;
    private InputAction pauseAction;
    private InputAction resetAction; // New action for reset

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component not found!");
            return;
        }

        pauseAction = playerInput.actions.FindAction("Pause");
        if (pauseAction == null)
        {
            Debug.LogError("Pause action not found!");
            return;
        }

        // New code: Setup reset action
        resetAction = playerInput.actions.FindAction("Reset");
        if (resetAction == null)
        {
            Debug.LogError("Reset action not found!");
            return;
        }

        pauseAction.performed += _ => TogglePause();
        resetAction.performed += _ => ResetLevel(); // Add callback for reset
    }

    private void OnEnable()
    {
        pauseAction.Enable();
        resetAction.Enable(); // Enable reset action
    }

    private void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.Disable();
        }
        if (resetAction != null)
        {
            resetAction.Disable(); // Disable reset action
        }
    }

    private void TogglePause()
    {
        bool isPaused = pauseMenuPanel.activeSelf;
        pauseMenuPanel.SetActive(!isPaused);
        Time.timeScale = isPaused ? 1f : 0f;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // New method: Reset the current level
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
    }
}

