using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StateMachine
{
    public GameState CurrentState { get; private set; }

    public void Initialize(GameState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void SwitchState(GameState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update() => CurrentState?.Update();

    internal void Initialize(List<State> playerStates)
    {
        throw new NotImplementedException();
    }
}

// В классе InputHandler (или другом месте управления вводом):
