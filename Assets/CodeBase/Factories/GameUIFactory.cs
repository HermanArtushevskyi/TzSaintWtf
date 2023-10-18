using CodeBase.Common;
using CodeBase.UI.Presenter;
using CodeBase.UI.View;
using UnityEngine;
using Zenject;

namespace CodeBase.Factories
{
    public class GameUIFactory : Interfaces.IFactory<GameView>
    {
        private readonly DiContainer _container;
        private readonly GameObject _uiPrefab;

        public GameUIFactory(DiContainer container,
            [InjectOptional(Id = GamePrefabID.UI)] GameObject uiPrefab)
        {
            _container = container;
            _uiPrefab = uiPrefab;
        }

        public GameView Create()
        {
            _container.InstantiatePrefab(_uiPrefab);
            GameView view = _container.Instantiate<GameView>();
            _container.Bind<GameView>().FromInstance(view).AsSingle().NonLazy();
            _container.Instantiate<GameViewPresenter>();
            
            return view;
        }
    }
}