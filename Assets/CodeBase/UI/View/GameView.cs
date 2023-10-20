using UnityEngine;

namespace CodeBase.UI.View
{
    public class GameView
    {
        private readonly GameObject _winPanel;

        public GameView(GameObject winPanel)
        {
            _winPanel = winPanel;
        }
        
        public void ShowWinPanel()
        {
            _winPanel.SetActive(true);
        }
    }
}