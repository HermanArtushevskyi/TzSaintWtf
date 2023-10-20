using CodeBase.StateMachine.States.GameStateMachine;

namespace CodeBase.StateMachine
{
    public class GameStateMachine : BaseStateMachine
    {
        public GameStateMachine()
        {
            States.Add(typeof(GameLoopState), new GameLoopState());
            States.Add(typeof(GameWinState), new GameWinState());
        }

        public override void Instantiate()
        {
            EnterState<GameLoopState>();
        }
    }
}