using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Canvas
{
    public class SceneTransitionViewBlocker : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _interactionBlocker;
        [SerializeField] private bool _startWithTransitionOff;

        private void Start()
        {
            if (_startWithTransitionOff)
            {
                TransitionOff();
            }
        }

        private void TransitionOff(Action onComplete = null)
        {
            _interactionBlocker.blocksRaycasts = true;

            _interactionBlocker.DOFade(0, 0.5f).SetEase(Ease.InQuad)
                .OnComplete(() =>
                {
                    _interactionBlocker.blocksRaycasts = false;
                    onComplete?.Invoke();
                });
        }

        public void TransitionOn(Action onComplete = null)
        {
            _interactionBlocker.blocksRaycasts = true;

            _interactionBlocker.DOFade(1, 0.5f).SetEase(Ease.OutQuad)
                .OnComplete(() => { onComplete?.Invoke(); });
        }
    }
}