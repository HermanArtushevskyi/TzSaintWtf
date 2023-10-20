using CodeBase.Common;
using CodeBase.Gameplay.Inventory.Interfaces;
using CodeBase.Gameplay.Items;
using UnityEngine;
using Zenject;

namespace CodeBase.Factories
{
    public class ItemFactory : Interfaces.IFactory<GameObject, int, Vector3>
    {
        private readonly DiContainer _container;
        private readonly IItem _resource1Prefab;
        private readonly IItem _resource2Prefab;
        private readonly IItem _resource3Prefab;

        public ItemFactory(
            DiContainer container,
            [InjectOptional(Id = GamePrefabID.Resource1)] IItem resource1Prefab,
            [InjectOptional(Id = GamePrefabID.Resource2)] IItem resource2Prefab,
            [InjectOptional(Id = GamePrefabID.Resource3)] IItem resource3Prefab)
        {
            _container = container;
            _resource1Prefab = resource1Prefab;
            _resource2Prefab = resource2Prefab;
            _resource3Prefab = resource3Prefab;
        }

        public GameObject Create(int tier, Vector3 position)
        {
            if (tier == 1)
                return CreateResource(_resource1Prefab, tier, position);
            if (tier == 2)
                return CreateResource(_resource2Prefab, tier, position);
            if (tier == 3)
                return CreateResource(_resource3Prefab, tier, position);
            
            return null;
        }

        private GameObject CreateResource(IItem resource1Prefab, int tier, Vector3 position)
        {
            GameObject go =
            _container.InstantiatePrefab(resource1Prefab.Prefab, position, Quaternion.identity, null);

            go.GetComponent<ItemBehaviour>().tier = tier;
            return go;
        }
    }
}