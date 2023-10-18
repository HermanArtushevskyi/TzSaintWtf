using System;
using System.Collections;
using CodeBase.Services.SceneLoader.Interfaces;
using CodeBase.Services.UnityContext;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public AsyncOperation LoadSceneAsync(string sceneName, bool allowActivation = true, Action onLoaded = null)
        {
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            loadSceneOperation.allowSceneActivation = allowActivation;
            _coroutineRunner.LoadCoroutine(LoadCoroutine(sceneName, allowActivation, onLoaded));
            return loadSceneOperation;
        }
        
        private IEnumerator LoadCoroutine(string sceneName, bool allowActivation, Action onLoaded)
        {
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            loadSceneOperation.allowSceneActivation = allowActivation;

            while (!loadSceneOperation.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}