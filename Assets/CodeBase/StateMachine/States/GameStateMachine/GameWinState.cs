using System;
using CodeBase.StateMachine.Interfaces;

namespace CodeBase.StateMachine.States.GameStateMachine
{
    public class GameWinState : IState
    {
        public static event Action OnWin;

        public void Enter()
        {
            OnWin?.Invoke();
        }

        public void Exit()
        {
            
        }
    }
}