public class Game
{
    private readonly Score _score;
    private const int StartScore = 5;

    public Game(Score score) => _score = score;

    public void StartGame() => _score.ModifyScore(StartScore);
    public void ExitGame() => _score.Reset();
}