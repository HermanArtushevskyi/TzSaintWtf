using CodeBase.Common;
using CodeBase.Gameplay.Buildings;
using CodeBase.Gameplay.Buildings.Interfaces;
using UnityEngine;
using Zenject;

namespace CodeBase.Factories
{
    public class BuildingFactory : Interfaces.IFactory<IBuilding, GamePrefabID>
    {
        private readonly GameObject _building1Prefab;
        private readonly GameObject _building2Prefab;
        private readonly GameObject _building3Prefab;
        private readonly GameObject _depotPrefab;
        private readonly GameObject _spawnpointB1;
        private readonly GameObject _spawnpointB2;
        private readonly GameObject _spawnpointB3;
        private readonly GameObject _spawnpointDepot;
        private readonly DiContainer _container;

        public BuildingFactory(
            [InjectOptional(Id = GamePrefabID.Building1)] GameObject building1Prefab,
            [InjectOptional(Id = GamePrefabID.Building2)] GameObject building2Prefab,
            [InjectOptional(Id = GamePrefabID.Building3)]GameObject building3Prefab,
            [InjectOptional(Id = GamePrefabID.Depot)] GameObject depotPrefab,
            [InjectOptional(Id = GamePrefabID.SpawnpointB1)] GameObject spawnpointB1,
            [InjectOptional(Id = GamePrefabID.SpawnpointB2)] GameObject spawnpointB2,
            [InjectOptional(Id = GamePrefabID.SpawnpointB3)] GameObject spawnpointB3,
            [InjectOptional(Id = GamePrefabID.SpawnpointDepot)] GameObject spawnpointDepot,
            DiContainer container)
        {
            _building1Prefab = building1Prefab;
            _building2Prefab = building2Prefab;
            _building3Prefab = building3Prefab;
            _depotPrefab = depotPrefab;
            
            _spawnpointB1 = spawnpointB1;
            _spawnpointB2 = spawnpointB2;
            _spawnpointB3 = spawnpointB3;
            _spawnpointDepot = spawnpointDepot;
            
            _container = container;
        }

        public IBuilding Create(GamePrefabID arg)
        {
            switch (arg)
            {
                case GamePrefabID.Building1:
                    return SpawnBuilding1();
                case GamePrefabID.Building2:
                    return SpawnBuilding2();
                case GamePrefabID.Building3:
                    return SpawnBuilding3();
                case GamePrefabID.Depot:
                    return SpawnDepot();
                default:
                    return null;
            }
        }

        private IBuilding SpawnBuilding(GameObject prefab, Transform spawnpoint, GamePrefabID id)
        {
            var building = _container.InstantiatePrefab(
                prefab, spawnpoint.transform.position, Quaternion.identity, null);

            _container.Bind<GameObject>().WithId(id).FromInstance(building).AsCached();
            
            return building.GetComponent<BuildingBehaviour>();
        }
        
        private IBuilding SpawnDepot() => SpawnBuilding(_depotPrefab, _spawnpointDepot.transform, GamePrefabID.DepotOnScene);

        private IBuilding SpawnBuilding3() => SpawnBuilding(_building3Prefab, _spawnpointB3.transform, GamePrefabID.Building3OnScene);

        private IBuilding SpawnBuilding2() => SpawnBuilding(_building2Prefab, _spawnpointB2.transform, GamePrefabID.Building2OnScene);

        private IBuilding SpawnBuilding1() => SpawnBuilding(_building1Prefab, _spawnpointB1.transform, GamePrefabID.Building1OnScene);
    }
}