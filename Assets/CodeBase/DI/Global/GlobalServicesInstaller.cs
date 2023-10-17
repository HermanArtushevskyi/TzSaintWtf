using System;
using System.Collections;
using CodeBase.Services.Curtain;
using CodeBase.Services.SceneLoader;
using CodeBase.Services.SceneLoader.Interfaces;
using CodeBase.Services.UnityContext;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GlobalServicesInstaller : MonoInstaller, ICoroutineRunner, IFixedUpdateCallback, IUpdateCallback
{
    public event Action OnUpdate;
    public event Action OnFixedUpdate;
    
    [SerializeField] private GameObject _curtainPrefab;

    public override void InstallBindings()
    {
        BindUnityContext();
        BindCurtain();
        BindSceneLoader();
    }

    public new void StartCoroutine(IEnumerator coroutine) => base.StartCoroutine(coroutine);
    
    private void BindUnityContext()
    {
        Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        Container.Bind<IUpdateCallback>().FromInstance(this).AsSingle();
        Container.Bind<IFixedUpdateCallback>().FromInstance(this).AsSingle();
    }

    private void BindCurtain() => Container.Bind<Curtain>().FromInstance(new Curtain(_curtainPrefab)).AsCached();

    private void BindSceneLoader() => Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

    private void Update() => OnUpdate?.Invoke();

    private void FixedUpdate() => OnFixedUpdate?.Invoke();
}