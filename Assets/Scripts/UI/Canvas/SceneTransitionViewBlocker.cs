using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Canvas
{
    public class SceneTransitionViewBlocker : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _interactionBlocker;
        [SerializeField] private Transform _viewBlocker;

        private void Start()
        {
            TransitionOff();
        }

        private void TransitionOff(Action onComplete = null)
        {
            _interactionBlocker.blocksRaycasts = true;
        
            _viewBlocker.DOMoveY(Screen.height, 1).SetEase(Ease.OutBounce)
                .OnComplete(() =>
                {
                    _interactionBlocker.blocksRaycasts = false;
                    onComplete?.Invoke();
                });
        }

        public void TransitionOn(Action onComplete = null)
        {
            _interactionBlocker.blocksRaycasts = true;

            _viewBlocker.DOMoveY(0, 1).SetEase(Ease.OutBounce)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                });
        }
    }
}