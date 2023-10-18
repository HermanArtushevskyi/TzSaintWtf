using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Services.UnityContext
{
    public class MonoContext : MonoBehaviour, IFixedUpdateCallback, IUpdateCallback, ICoroutineRunner
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        
        public void LoadCoroutine(IEnumerator coroutine) => StartCoroutine(coroutine);

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
        
        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}