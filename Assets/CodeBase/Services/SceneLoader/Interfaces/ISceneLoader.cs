using System;
using UnityEngine;

namespace CodeBase.Services.SceneLoader.Interfaces
{
    public interface ISceneLoader
    {
        public void LoadScene(string name);
        public AsyncOperation LoadSceneAsync(string sceneName, bool allowActivation = true, Action onLoaded = null);
    }
}