using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Canvas
{
    public abstract class BaseCanvas : MonoBehaviour
    {
        [SerializeField] private string _sceneNavigationTargetScene;

        [SerializeField] private CanvasLayerContainer[] _canvasLayers;
        [SerializeField] private SceneTransitionViewBlocker _sceneTransition;

        private readonly Dictionary<CanvasLayer, Transform> _canvasLayersByType = new();

        protected virtual void Awake()
        {
            foreach (var container in _canvasLayers)
            {
                _canvasLayersByType.Add(container.Layer, container.Parent);
            }
        }

        protected virtual void OnDestroy()
        {
        }

        protected BaseView CreateView(BaseView prefab, CanvasLayer layer)
        {
            var view = Instantiate(prefab, GetLayer(layer)).Initialize();
            view.Open();
            
            return view;
        }

        protected void NavigateToScene()
        {
            _sceneTransition.TransitionOn(() => SceneManager.LoadScene(_sceneNavigationTargetScene));
        }

        private Transform GetLayer(CanvasLayer layer)
        {
            if (!_canvasLayersByType.ContainsKey(layer))
            {
                Debug.LogError($"Layer {layer} not defined!");
                return null;
            }

            return _canvasLayersByType[layer];
        }
    }
}