using System.Collections;

namespace CodeBase.Services.UnityContext
{
    public interface ICoroutineRunner
    {
        public void LoadCoroutine(IEnumerator coroutine);
    }
}