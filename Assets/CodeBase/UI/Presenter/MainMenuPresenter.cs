using CodeBase.Services.SceneLoader.Interfaces;
using CodeBase.UI.View;

namespace CodeBase.UI.Presenter
{
    public class MainMenuPresenter
    {
        private readonly ISceneLoader _sceneLoader;

        public MainMenuPresenter(MainMenuView view, ISceneLoader sceneLoader)
        {
            view.PlayClicked += LoadGameScene;
            _sceneLoader = sceneLoader;
        }

        private void LoadGameScene() => _sceneLoader.LoadScene("Game");
    }
}