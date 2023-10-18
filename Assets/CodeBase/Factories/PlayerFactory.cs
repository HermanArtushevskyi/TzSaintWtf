using CodeBase.Common;
using CodeBase.Gameplay.InputProvider.Interfaces;
using CodeBase.Services.UnityContext;
using UnityEngine;
using Zenject;
using CharacterController = CodeBase.Gameplay.CharacterController.CharacterController;
using IFactories = CodeBase.Factories.Interfaces;

namespace CodeBase.Factories
{
    public class PlayerFactory : IFactories.IFactory<CharacterController, IInputProvider>
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;
        private readonly IFixedUpdateCallback _fixedUpdateCallback;

        public PlayerFactory(DiContainer container,
            [InjectOptional(Id = GamePrefabID.Player)] GameObject playerPrefab,
            IFixedUpdateCallback fixedUpdateCallback)
        {
            _container = container;
            _playerPrefab = playerPrefab;
            _fixedUpdateCallback = fixedUpdateCallback;
        }

        public CharacterController Create(IInputProvider inputProvider)
        {
            GameObject player = _container.InstantiatePrefab(_playerPrefab);
            CharacterController characterController = player.GetComponent<CharacterController>();
            _container.Bind<GameObject>().WithId(GamePrefabID.PlayerOnScene).FromInstance(player).AsSingle().NonLazy();
            
            return characterController;
        }
    }
}