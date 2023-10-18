using UnityEditor;
using UnityEditor.SceneManagement;

namespace Editor.Tools
{
    public static class PlayButton
    {
        [MenuItem("Tools/Play")]
        public static void ClickPlayButton()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Boot.unity");
            EditorApplication.EnterPlaymode();
        }
    }
}