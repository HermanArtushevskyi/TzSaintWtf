using CodeBase.StateMachine.States.GameStateMachine;
using CodeBase.UI.View;

namespace CodeBase.UI.Presenter
{
    public class GameViewPresenter
    {
        private readonly GameView _view;

        public GameViewPresenter(GameView view)
        {
            _view = view;
            GameWinState.OnWin += _view.ShowWinPanel;
        }
    }
}