namespace CodeBase.StateMachine.Interfaces
{
    public interface IStateWithPayload : IExitableState
    {
        public void Enter<TPayload>(TPayload payload);
    }
}