using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private PlayerInput playerInput;
    private InputAction pauseAction;

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

        // Register the pause action callback
        pauseAction.performed += _ => TogglePause();
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.Disable();
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
}
