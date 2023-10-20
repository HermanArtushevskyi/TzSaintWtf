using CodeBase.Common;
using CodeBase.Gameplay.Inventory.Interfaces;
using TNRD;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.Game
{
    public class GamePrefabsInstaller : MonoInstaller
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _uiPrefab;
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private GameObject _building1Prefab;
        [SerializeField] private GameObject _building2Prefab;
        [SerializeField] private GameObject _building3Prefab;
        [SerializeField] private GameObject _depotPrefab;
        [SerializeField] private SerializableInterface<IItem> _resource1;
        [SerializeField] private SerializableInterface<IItem> _resource2;
        [SerializeField] private SerializableInterface<IItem> _resource3;
        
        [Space(10f)]
        [Header("On scene objects")]
        [SerializeField] private GameObject _spawnpoint;
        [SerializeField] private GameObject _spawnpointB1;
        [SerializeField] private GameObject _spawnpointB2;
        [SerializeField] private GameObject _spawnpointB3;
        [SerializeField] private GameObject _spawnpointDepot;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId(GamePrefabID.Player).FromInstance(_playerPrefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.UI).FromInstance(_uiPrefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.Camera).FromInstance(_cameraPrefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.Spawnpoint).FromInstance(_spawnpoint);
            Container.Bind<GameObject>().WithId(GamePrefabID.SpawnpointB1).FromInstance(_spawnpointB1);
            Container.Bind<GameObject>().WithId(GamePrefabID.SpawnpointB2).FromInstance(_spawnpointB2);
            Container.Bind<GameObject>().WithId(GamePrefabID.SpawnpointB3).FromInstance(_spawnpointB3);
            Container.Bind<GameObject>().WithId(GamePrefabID.SpawnpointDepot).FromInstance(_spawnpointDepot);
            Container.Bind<GameObject>().WithId(GamePrefabID.Building1).FromInstance(_building1Prefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.Building2).FromInstance(_building2Prefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.Building3).FromInstance(_building3Prefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.Depot).FromInstance(_depotPrefab).AsCached();
            Container.Bind<IItem>().WithId(GamePrefabID.Resource1).FromInstance(_resource1.Value).AsCached();
            Container.Bind<IItem>().WithId(GamePrefabID.Resource2).FromInstance(_resource2.Value).AsCached();
            Container.Bind<IItem>().WithId(GamePrefabID.Resource3).FromInstance(_resource3.Value).AsCached();
        }
    }
}