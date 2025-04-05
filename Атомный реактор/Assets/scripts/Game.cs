using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;
    public static Game Instance => instance;

    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private GameTimer gameTimer;

    private bool isGameActive;

    public void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameActive = true;
        gameTimer.StartTimer();
        gameOverPanel.Hide();
    }

    public void GameOver()
    {
        isGameActive = false;
        gameTimer.StopTimer();
        gameOverPanel.Show();
    }

    public bool IsGameActive => isGameActive;
}
