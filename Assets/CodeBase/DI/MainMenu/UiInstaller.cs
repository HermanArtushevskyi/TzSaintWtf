using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private Button _playBtn;
    
    public override void InstallBindings()
    {
        Container.Bind<Button>().FromInstance(_playBtn).AsCached();
    }
}