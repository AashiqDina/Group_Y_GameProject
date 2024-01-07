using UnityEngine;

public enum GameDifficulty
{
    Easy,
    Medium,
    Hard
}

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }
    public GameDifficulty currentDifficulty = GameDifficulty.Easy; // Default difficulty

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetDamageBasedOnDifficulty()
    {
        switch (currentDifficulty)
        {
            case GameDifficulty.Easy:
                return 5;
            case GameDifficulty.Medium:
                return 10;
            case GameDifficulty.Hard:
                return 15;
            default:
                return 5;
        }
    }

    public void SetDifficulty(GameDifficulty difficulty)
    {
        currentDifficulty = difficulty;
    }
}
