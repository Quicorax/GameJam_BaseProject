using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Quicorax.Editor
{
    public class SceneSwitcher : EditorWindow
    {
        private Vector2 _scrollPos;

        [MenuItem("Quicorax/Scene Switcher")]
        private static void Init()
        {
            var window = GetWindow(typeof(SceneSwitcher), false, "Scene Switcher");
            window.Show();
        }

        private void OnGUI()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (GUILayout.Button(System.IO.Path.GetFileNameWithoutExtension(scene.path)))
                    EditorSceneManager.OpenScene(scene.path);
            }

            EditorGUILayout.EndScrollView();
        }
    }
}