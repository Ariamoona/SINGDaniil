using UnityEngine;
using System.Collections.Generic;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private List<State> playerStates;

    private void Awake()
    {
        InitializePlayerStateMachine();
        InitializeGameStateMachine();
    }

    private void InitializePlayerStateMachine()
    {
        var stateMachine = new StateMachine();
        stateMachine.Initialize(playerStates);
    }

    private void InitializeGameStateMachine()
    {
        var gameStates = new List<GameState>
        {
            new GamePlayState(),
            new PauseState(),
            new FinalState()
        };

        GameStateMachine.Instance.Initialize(gameStates);
    }

    private void Update()
    {
        GameStateMachine.Instance.ProcessStateUpdate(); // Исправленный вызов
    }

    private class GamePlayState : GameState
    {
    }

    private class FinalState : GameState
    {
    }
}
