using System;
using System.Collections.Generic;
using CodeBase.StateMachine.Interfaces;

namespace CodeBase.StateMachine
{
    public abstract class BaseStateMachine : IStateMachine
    {
        protected IExitableState CurrentState;
        protected Dictionary<Type, IExitableState> States;
        
        public void EnterState<TExitableState>() where TExitableState : IExitableState
        {
            CurrentState?.Exit();
            CurrentState = States[typeof(TExitableState)];
            (CurrentState as IState).Enter();
        }

        public void EnterState<TExitableState, TPayload>(TPayload payload) where TExitableState : IExitableState
        {
            CurrentState?.Exit();
            CurrentState = States[typeof(TExitableState)];
            (CurrentState as IStateWithPayload).Enter(payload);
        }
    }
}