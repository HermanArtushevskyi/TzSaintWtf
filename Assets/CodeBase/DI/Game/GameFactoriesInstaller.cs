using CodeBase.Common;
using CodeBase.Factories;
using CodeBase.Gameplay.InputProvider.Interfaces;
using CodeBase.StateMachine.Interfaces;
using CodeBase.UI.View;
using UnityEngine;
using Zenject;
using CharacterController = CodeBase.Gameplay.CharacterController.CharacterController;
using IFactories = CodeBase.Factories.Interfaces;

namespace CodeBase.DI.Game
{
    public class GameFactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IFactories.IFactory<GameView>>().To<GameUIFactory>().AsSingle();
            Container.Bind<IFactories.IFactory<CharacterController, IInputProvider>>().To<PlayerFactory>().AsSingle();
            Container.Bind<IFactories.IFactory<Camera>>().To<GameCameraFactory>().AsSingle();
            Container.Bind<IFactories.IFactory<IInputProvider>>().To<InputFactory>().AsSingle();

            Container.Bind<IFactories.IFactory<IStateMachine>>().WithId(GameStateMachineID.Player)
                .To<PlayerStateMachineFactory>().AsCached();
        }
    }
}