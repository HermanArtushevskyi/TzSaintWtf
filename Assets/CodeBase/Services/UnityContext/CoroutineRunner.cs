using System.Collections;
using UnityEngine;

namespace CodeBase.Services.UnityContext
{
    public interface ICoroutineRunner
    {
        public void StartCoroutine(IEnumerator coroutine);
    }
}