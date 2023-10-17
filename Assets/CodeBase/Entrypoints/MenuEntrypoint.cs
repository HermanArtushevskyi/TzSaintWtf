using CodeBase.Services.SceneLoader.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Entrypoints
{
    public class MenuEntrypoint : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader, Button playBtn)
        {
            _sceneLoader = sceneLoader;
            playBtn.onClick.AddListener(OnPlay);
        }

        private void OnPlay()
        {
            _sceneLoader.LoadSceneAsync("Game");
        }
    }
}