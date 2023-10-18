using CodeBase.Common;
using CodeBase.Gameplay.InputProvider.Interfaces;
using CodeBase.Services.UnityContext;
using CodeBase.StateMachine.States.PlayerStateMachine;
using UnityEngine;
using Zenject;
using CharacterController = CodeBase.Gameplay.CharacterController.CharacterController;

namespace CodeBase.StateMachine
{
    public class PlayerStateMachine : BaseStateMachine
    {
        public PlayerStateMachine(
            IFixedUpdateCallback update,
            [InjectOptional(Id = GamePrefabID.PlayerOnScene)] GameObject player,
            IInputProvider inputProvider)
        {
            States.Add(typeof(PlayerPlayState), new PlayerPlayState(update, player.GetComponent<CharacterController>(), inputProvider));
            States.Add(typeof(PlayerWonState), new PlayerWonState());
        }

        public override void Instantiate()
        {
            EnterState<PlayerPlayState>();
        }
    }
}