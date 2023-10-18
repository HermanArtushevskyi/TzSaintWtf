using System;
using CodeBase.Common;
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
        private IFactories.IFactory<CharacterController, IInputProvider> _playerFactory;
        private IFactories.IFactory<IStateMachine> _playerStateMachineFactory;

        [Inject]
        private void Construct(
            IFactories.IFactory<CharacterController, IInputProvider> playerFactory,
            IFactories.IFactory<GameView> uiFactory,
            IFactories.IFactory<Camera> cameraFactory,
            IFactories.IFactory<IInputProvider> inputFactory,
            [InjectOptional(Id = GameStateMachineID.Player)] IFactories.IFactory<IStateMachine> playerStateMachineFactory)
        {
            _inputFactory = inputFactory;
            _uiFactory = uiFactory;
            _playerFactory = playerFactory;
            _playerStateMachineFactory = playerStateMachineFactory;
        }

        private void Start()
        {
            IInputProvider inputProvider = _inputFactory.Create();
            _uiFactory.Create();
            _playerFactory.Create(inputProvider);
            _playerStateMachineFactory.Create().Instantiate();
        }
    }
}