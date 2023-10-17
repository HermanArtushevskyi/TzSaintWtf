using CodeBase.Common;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.Game
{
    public class GamePrefabsInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _uiPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId(GamePrefabID.Player).FromInstance(_playerPrefab).AsCached();
            Container.Bind<GameObject>().WithId(GamePrefabID.UI).FromInstance(_uiPrefab).AsCached();
        }
    }
}