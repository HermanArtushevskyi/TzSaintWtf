using CodeBase.Common;
using CodeBase.UI.Presenter;
using CodeBase.UI.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Factories
{
    public class MenuUIFactory : Interfaces.IFactory<MainMenuView>
    {
        private readonly DiContainer _container;
        private readonly GameObject _uiPrefab;

        public MenuUIFactory(DiContainer container,
            [InjectOptional(Id = MenuPrefabID.UI)] GameObject uiPrefab)
        {
            _container = container;
            _uiPrefab = uiPrefab;
        }

        public MainMenuView Create()
        {
            GameObject uiGo = _container.InstantiatePrefab(_uiPrefab);
            MainMenuView view = new MainMenuView(uiGo.GetComponentInChildren<Button>());
            
            _container.Bind<MainMenuView>().FromInstance(view).AsSingle().NonLazy();
            _container.Instantiate<MainMenuPresenter>();
            return view;
        }
    }
}