using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Services.Editor
{
    public class SceneSwitcherWindow : EditorWindow
    {
        private Vector2 _scrollPos;

        [MenuItem("Quicorax/SceneSwitcher Window")]
        private static void Init()
        {
            var window = GetWindow(typeof(SceneSwitcherWindow), false, "Scene Switcher");
            window.Show();
        }

        private void OnGUI()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (GUILayout.Button(System.IO.Path.GetFileNameWithoutExtension(scene.path)))
                {
                    EditorSceneManager.OpenScene(scene.path);
                }
            }

            EditorGUILayout.EndScrollView();
        }
    }
}