using CodeBase.Common;
using CodeBase.StateMachine;
using CodeBase.StateMachine.Interfaces;
using Zenject;

namespace CodeBase.Factories
{
    public class GameStateMachineFactory : Interfaces.IFactory<IStateMachine>
    {
        private readonly DiContainer _container;

        public GameStateMachineFactory(DiContainer container)
        {
            _container = container;
        }

        public IStateMachine Create()
        {
            GameStateMachine stateMachine = _container.Instantiate<GameStateMachine>();

            _container.Bind<IStateMachine>().WithId(GameStateMachineID.Game).FromInstance(stateMachine).AsCached();

            return stateMachine;
        }
    }
}