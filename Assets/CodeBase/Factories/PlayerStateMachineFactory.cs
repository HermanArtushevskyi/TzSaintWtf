using CodeBase.Common;
using CodeBase.StateMachine;
using CodeBase.StateMachine.Interfaces;
using Zenject;

namespace CodeBase.Factories
{
    public class PlayerStateMachineFactory : Interfaces.IFactory<IStateMachine>
    {
        private readonly DiContainer _container;

        public PlayerStateMachineFactory(DiContainer container)
        {
            _container = container;
        }

        public IStateMachine Create()
        {
            IStateMachine stateMachine = _container.Instantiate<PlayerStateMachine>();
            _container.Bind<IStateMachine>().WithId(GameStateMachineID.Player).FromInstance(stateMachine).AsCached();
            return stateMachine;
        }
    }
}