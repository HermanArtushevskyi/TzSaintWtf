using CodeBase.Common;
using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private GameObject _uiPrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId(MenuPrefabID.UI).FromInstance(_uiPrefab).AsCached();
    }
}