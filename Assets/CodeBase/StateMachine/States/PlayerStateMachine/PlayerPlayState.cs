using CodeBase.Gameplay.InputProvider.Interfaces;
using CodeBase.Services.UnityContext;
using CodeBase.StateMachine.Interfaces;
using UnityEngine;
using CharacterController = CodeBase.Gameplay.CharacterController.CharacterController;

namespace CodeBase.StateMachine.States.PlayerStateMachine
{
    public class PlayerPlayState : IState
    {
        private readonly IFixedUpdateCallback _update;
        private readonly CharacterController _controller;
        private readonly IInputProvider _inputProvider;

        public PlayerPlayState(IFixedUpdateCallback update, CharacterController controller, IInputProvider inputProvider)
        {
            _update = update;
            _controller = controller;
            _inputProvider = inputProvider;
        }

        public void Enter()
        {
            _update.OnFixedUpdate += OnFixedUpdate;
        }

        public void Exit()
        {
            _update.OnFixedUpdate -= OnFixedUpdate;
        }
        
        private void OnFixedUpdate()
        {
            _controller.ProvideInput(_inputProvider.GetInput());
        }
    }
}