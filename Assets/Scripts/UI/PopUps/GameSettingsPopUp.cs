using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameSettingsPopUp : SettingsPopUp
{
    [SerializeField] private Button _exitButton;
    private Action _onExit;

    public void AddOnExitAction(Action onExit)
    {
        _onExit = onExit;
    }

    private void Awake()
    {
        _exitButton.onClick.AddListener(HandleExit);
    }

    private void OnDestroy()
    {
        _exitButton.onClick.RemoveAllListeners();
    }

    private void HandleExit()
    {
        _exitButton.interactable = false;
        
        Close(()=> _onExit.Invoke());
    }
}