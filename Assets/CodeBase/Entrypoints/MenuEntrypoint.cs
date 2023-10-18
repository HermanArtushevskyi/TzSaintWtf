using CodeBase.UI.View;
using IFactories = CodeBase.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace CodeBase.Entrypoints
{
    public class MenuEntrypoint : MonoBehaviour
    {
        [Inject]
        private void Construct(IFactories.IFactory<MainMenuView> uiFactory)
        {
            uiFactory.Create();
        }
    }
}