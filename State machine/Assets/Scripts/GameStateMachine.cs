using UnityEngine;
using System.Collections.Generic;
public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance { get; private set; }

    private StateMachine stateMachine;
    private bool isInFinalState;
    private int currentStateIndex;

    private List<GameState> gameStates = new List<GameState>();

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

    public void Initialize(List<GameState> states)
    {
        gameStates = states;
        currentStateIndex = 0;
        stateMachine = new StateMachine();
        stateMachine.Initialize(gameStates[currentStateIndex]);
    }

    public void SwitchToNextState()
    {
        if (isInFinalState) return;

        currentStateIndex = (currentStateIndex + 1) % gameStates.Count;
        stateMachine.SwitchState(gameStates[currentStateIndex]);
    }

    public void SwitchToPause() => SwitchToState(typeof(PauseState));
    public void SwitchToGame() => SwitchToState(typeof(GamePlayState));
    public void SwitchToFinal() => SwitchToState(typeof(FinalState));

    private void SwitchToState(System.Type stateType)
    {
        foreach (var state in gameStates)
        {
            if (state.GetType() == stateType)
            {
                stateMachine.SwitchState(state);
                if (stateType == typeof(FinalState)) isInFinalState = true;
                return;
            }
        }
    }

    public void ProcessStateUpdate() => stateMachine?.Update();

    private class GamePlayState
    {
    }

    private class FinalState
    {
    }
}
