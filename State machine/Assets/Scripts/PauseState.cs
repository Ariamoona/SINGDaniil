using UnityEngine;

public class PauseState : GameState
{
    public override void Enter()
    {
        Time.timeScale = 0f;
        // Show pause menu
    }

    public override void Exit()
    {
        Time.timeScale = 1f;
        // Hide pause menu
    }
}