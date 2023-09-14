using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseView : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private Image _image;
    [SerializeField] private Button _specificCloseButton;
    [SerializeField] private Button _backgroundCloseButton;

    [SerializeField] private float _openTime = 0.5f;
    [SerializeField] private float _closeTime = 0.5f;

    private Tween _imageTween;
    private Tween _scaleTween;
    private bool _onTransition;
    
    public BaseView Initialize()
    {
        _backgroundCloseButton.onClick.AddListener(()=> Close());
        _specificCloseButton.onClick.AddListener(()=> Close());

        ConfigureInitialState();
        return this;
    }

    public void Open()
    {
        if (_onTransition)
        {
            return;
        }

        PreOpen();
        _imageTween = _image.DOFade(0.5f, _openTime);
        _scaleTween = _content.DOScale(1, _openTime).SetEase(Ease.OutBack).OnComplete(PostOpen);
    }

    public void Close(Action onPostClose = null)
    {
        if (_onTransition)
        {
            return;
        }

        PreClose();
        _imageTween = _image.DOFade(0, _closeTime);
        _scaleTween = _content.DOScale(0, _closeTime).SetEase(Ease.InBack).OnComplete(()=> PostClose(onPostClose));
    }

    protected virtual void PreOpen()
    {
        _image.raycastTarget = true;
        _onTransition = true;
    }

    protected virtual void PostOpen()
    {
        _onTransition = false;
    }

    protected virtual void PreClose()
    {
        _onTransition = true;
    }

    protected virtual void PostClose(Action onPostClose = null)
    {
        _image.raycastTarget = false;
        _onTransition = false;
        
        onPostClose?.Invoke();
    }

    private void ConfigureInitialState()
    {
        _image.raycastTarget = false;
        _imageTween = _image.DOFade(0, 0);
        _content.localScale = Vector3.zero;
    }

    private void OnDestroy()
    {
        _backgroundCloseButton.onClick.RemoveAllListeners();
        _specificCloseButton.onClick.RemoveAllListeners();

        _imageTween.Kill();
        _scaleTween.Kill();
    }
}