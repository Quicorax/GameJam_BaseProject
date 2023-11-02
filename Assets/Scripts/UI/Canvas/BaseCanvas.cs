using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI.Canvas
{
    public abstract class BaseCanvas : MonoBehaviour
    {
        [SerializeField] private string _sceneNavigationTargetScene;

        [SerializeField] private CanvasLayerContainer[] _canvasLayers;
        [SerializeField] private SceneTransitionViewBlocker _sceneTransition;

        private readonly Dictionary<CanvasLayer, Transform> _canvasLayersByType = new();
        
        private IInstancer _instancer;

        [Inject]
        public void Construct(IInstancer instancer)
        {
            _instancer = instancer;
        }
        
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

        protected T CreateView<T>(GameObject prefab, CanvasLayer layer) where T : BaseView
        {
            var view = _instancer.Create<T>(prefab, GetLayer(layer)).Initialize();
            view.Open();
            
            return view as T;
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