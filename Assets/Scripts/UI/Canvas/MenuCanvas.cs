using Services.Runtime.AudioService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Canvas
{
    public class MenuCanvas : BaseCanvas
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;

        [SerializeField] private GameObject _settingsPopUp;
        [SerializeField] private GameObject _creditsPopUp;
        
        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
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
            _audioService.PlaySFX("SFX");

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