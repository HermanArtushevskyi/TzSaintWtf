using System;
using UnityEngine.UI;

namespace CodeBase.UI.View
{
    public class MainMenuView
    {
        public event Action PlayClicked;

        public MainMenuView(Button playBtn)
        {
            playBtn.onClick.AddListener(() => PlayClicked?.Invoke());
        }
    }
}