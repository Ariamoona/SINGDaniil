using UnityEngine.Events;

public class Score
{
    public int CurrentScore { get; private set; }
    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();

    public void ModifyScore(int value)
    {
        CurrentScore += value;
        OnScoreChanged.Invoke(CurrentScore);
    }

    public void Reset() => ModifyScore(-CurrentScore);
}