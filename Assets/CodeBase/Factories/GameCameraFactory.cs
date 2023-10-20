using Cinemachine;
using CodeBase.Common;
using IFactories = CodeBase.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace CodeBase.Factories
{
    public class GameCameraFactory : IFactories.IFactory<Camera, GameObject>
    {
        private readonly GameObject _cameraPrefab;
        private readonly DiContainer _container;

        public GameCameraFactory(
            [InjectOptional(Id = GamePrefabID.Camera)] GameObject cameraPrefab,
            DiContainer container)
        {
            _cameraPrefab = cameraPrefab;
            _container = container;
        }

        public Camera Create(GameObject player)
        {
            GameObject camera = _container.InstantiatePrefab(_cameraPrefab);
            var cinemachine = camera.GetComponentInChildren<CinemachineVirtualCamera>();
            
            cinemachine.Follow = player.transform;
            cinemachine.LookAt = player.transform;
            
            return camera.GetComponent<Camera>();
        }
    }
}