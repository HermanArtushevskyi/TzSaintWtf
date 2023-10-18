namespace CodeBase.StateMachine.Interfaces
{
    public interface IStateMachine
    {
        public void EnterState<TExitableState>() where TExitableState : IExitableState;
        public void EnterState<TExitableState, TPayload>(TPayload payload) where TExitableState : IExitableState;

        public void Instantiate();
    }
}