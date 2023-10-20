using CodeBase.Common;
using CodeBase.Factories;
using CodeBase.Gameplay.Buildings.Interfaces;
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
            Container.Bind<IFactories.IFactory<Camera, GameObject>>().To<GameCameraFactory>().AsSingle();
            Container.Bind<IFactories.IFactory<IInputProvider>>().To<InputFactory>().AsSingle();
            Container.Bind<IFactories.IFactory<IBuilding, GamePrefabID>>().To<BuildingFactory>().AsSingle();
            Container.Bind<IFactories.IFactory<IStateMachine>>().WithId(GameStateMachineID.Player)
                .To<PlayerStateMachineFactory>().AsCached();
            Container.Bind<IFactories.IFactory<IStateMachine>>().WithId(GameStateMachineID.Game)
                .To<GameStateMachineFactory>().AsCached();
            Container.Bind<IFactories.IFactory<GameObject, int, Vector3>>().To<ItemFactory>().AsSingle();
        }
    }
}