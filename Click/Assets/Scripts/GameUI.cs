using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public void Initialize(Score score)
    {
        score.OnScoreChanged.AddListener(UpdateScoreDisplay);
        UpdateScoreDisplay(score.CurrentScore);
    }

    private void UpdateScoreDisplay(int score) =>
        _scoreText.text = $"Score: {score}";
}