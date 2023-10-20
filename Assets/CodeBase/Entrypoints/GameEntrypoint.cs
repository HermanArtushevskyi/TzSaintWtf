using System;
using CodeBase.Common;
using CodeBase.Gameplay.Buildings.Interfaces;
using CodeBase.Gameplay.InputProvider.Interfaces;
using CodeBase.StateMachine.Interfaces;
using CodeBase.UI.View;
using UnityEngine;
using Zenject;
using CharacterController = CodeBase.Gameplay.CharacterController.CharacterController;
using IFactories = CodeBase.Factories.Interfaces;

namespace CodeBase.Entrypoints
{
    public class GameEntrypoint : MonoBehaviour
    {
        private IFactories.IFactory<IInputProvider> _inputFactory;
        private IFactories.IFactory<GameView> _uiFactory;
        private IFactories.IFactory<Camera, GameObject> _cameraFactory;
        private IFactories.IFactory<CharacterController, IInputProvider> _playerFactory;
        private IFactories.IFactory<IStateMachine> _playerStateMachineFactory;
        private IFactories.IFactory<IStateMachine> _gameStateMachineFactory;
        private IFactories.IFactory<IBuilding, GamePrefabID> _buildingFactory;

        [Inject]
        private void Construct(
            IFactories.IFactory<CharacterController, IInputProvider> playerFactory,
            IFactories.IFactory<GameView> uiFactory,
            IFactories.IFactory<Camera, GameObject> cameraFactory,
            IFactories.IFactory<IInputProvider> inputFactory,
            [InjectOptional(Id = GameStateMachineID.Player)] IFactories.IFactory<IStateMachine> playerStateMachineFactory,
            [InjectOptional(Id = GameStateMachineID.Game)] IFactories.IFactory<IStateMachine> gameStateMachineFactory,
            IFactories.IFactory<IBuilding, GamePrefabID> buildingFactory)
        {
            _inputFactory = inputFactory;
            _uiFactory = uiFactory;
            _cameraFactory = cameraFactory;
            _playerFactory = playerFactory;
            _playerStateMachineFactory = playerStateMachineFactory;
            _gameStateMachineFactory = gameStateMachineFactory;
            _buildingFactory = buildingFactory;
        }

        private void Start()
        {
            IInputProvider inputProvider = _inputFactory.Create();
            _uiFactory.Create();
            CharacterController playerController = _playerFactory.Create(inputProvider);
            _cameraFactory.Create(playerController.gameObject);
            _playerStateMachineFactory.Create().Instantiate();
            _gameStateMachineFactory.Create().Instantiate();
            ;
            _buildingFactory.Create(GamePrefabID.Building1);
            _buildingFactory.Create(GamePrefabID.Building2);
            _buildingFactory.Create(GamePrefabID.Building3);
            _buildingFactory.Create(GamePrefabID.Depot);
        }
    }
}