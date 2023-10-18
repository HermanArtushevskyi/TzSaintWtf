using System;
using System.Collections;
using CodeBase.Services.Curtain;
using CodeBase.Services.SceneLoader;
using CodeBase.Services.SceneLoader.Interfaces;
using CodeBase.Services.UnityContext;
using MyInput;
using UnityEngine;
using Zenject;

public class GlobalServicesInstaller : MonoInstaller
{
    [SerializeField] private GameObject _curtainPrefab;
    [SerializeField] private MonoContext _monoContext;

    public override void InstallBindings()
    {
        BindUnityContext();
        BindCurtain();
        BindSceneLoader();
        BindInput();
    }

    private void BindUnityContext()
    {
        Container.Bind<ICoroutineRunner>().FromInstance(_monoContext).AsSingle();
        Container.Bind<IUpdateCallback>().FromInstance(_monoContext).AsSingle();
        Container.Bind<IFixedUpdateCallback>().FromInstance(_monoContext).AsSingle();
    }

    private void BindCurtain() => Container.Bind<Curtain>().FromInstance(new Curtain(_curtainPrefab)).AsCached();

    private void BindSceneLoader() => Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

    private void BindInput() => Container.Bind<InputActions>().AsSingle().NonLazy();
}