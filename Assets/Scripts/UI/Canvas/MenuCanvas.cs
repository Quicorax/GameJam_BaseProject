using UnityEngine;
using UnityEngine.UI;

namespace UI.Canvas
{
    public class MenuCanvas : BaseCanvas
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;

        [SerializeField] private GameObject _settingsPopUp;
        [SerializeField] private GameObject _creditsPopUp;
        
        protected override void Awake()
        {
            _playButton.onClick.AddListener(HandlePlay);
            _settingsButton.onClick.AddListener(HandleSettings);
            _creditsButton.onClick.AddListener(HandleCredits);
            base.Awake();
        }

        protected override void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.RemoveAllListeners();
            base.OnDestroy();
        }

        private void HandlePlay()
        {
            NavigateToScene();
        }

        private void HandleSettings()
        {
            CreateView<SettingsPopUp>(_settingsPopUp, CanvasLayer.PopUps);
        }

        private void HandleCredits()
        {
            CreateView<CreditsPopUp>(_creditsPopUp, CanvasLayer.PopUps);
        }
    }
}