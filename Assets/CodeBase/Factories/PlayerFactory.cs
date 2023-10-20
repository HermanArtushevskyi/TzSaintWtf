using CodeBase.Common;
using CodeBase.Gameplay.InputProvider.Interfaces;
using CodeBase.Gameplay.Inventory;
using CodeBase.Gameplay.Inventory.Interfaces;
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
        private readonly GameObject _spawnpoint;
        private readonly IFixedUpdateCallback _fixedUpdateCallback;

        public PlayerFactory(DiContainer container,
            [InjectOptional(Id = GamePrefabID.Player)] GameObject playerPrefab,
            [InjectOptional(Id = GamePrefabID.Spawnpoint)] GameObject spawnpoint,
            IFixedUpdateCallback fixedUpdateCallback)
        {
            _container = container;
            _playerPrefab = playerPrefab;
            _spawnpoint = spawnpoint;
            _fixedUpdateCallback = fixedUpdateCallback;
        }

        public CharacterController Create(IInputProvider inputProvider)
        {
            GameObject player =
                _container.InstantiatePrefab(_playerPrefab, _spawnpoint.transform.position,Quaternion.identity, null);
            CharacterController characterController = player.GetComponent<CharacterController>();
            _container.Bind<GameObject>().WithId(GamePrefabID.PlayerOnScene).FromInstance(player).AsSingle().NonLazy();
            _container.Bind<IInventory>().FromInstance(player.GetComponent<Inventory>()).AsSingle();
            
            return characterController;
        }
    }
}