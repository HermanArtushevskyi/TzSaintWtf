using CodeBase.Services.SceneLoader.Interfaces;
using UnityEngine;
using Zenject;

namespace CodeBase.Entrypoints
{
    public class AppEntrypoint : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start() => _sceneLoader.LoadSceneAsync("MainMenu");
    }
}