using System;
using UnityEngine;

namespace CodeBase.Services.SceneLoader.Interfaces
{
    public interface ISceneLoader
    {
        public AsyncOperation LoadSceneAsync(string sceneName, bool allowActivation = true, Action onLoaded = null);
    }
}