using Services.Runtime.AudioService;
using Services.Runtime.Localization;
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

        [SerializeField] private BaseView _settingsPopUp;
        [SerializeField] private BaseView _creditsPopUp;

        private IAudioService _audioService;
        private ILocalizationService _localizationService;
        
        [Inject]
        public void Construct(IAudioService audioService, ILocalizationService localizationService)
        {
            _audioService = audioService;
            _localizationService = localizationService;
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
            Debug.Log(_localizationService.Localize("CAT"));
            NavigateToScene();
        }

        private void HandleSettings()
        {
            CreateView(_settingsPopUp, CanvasLayer.PopUps);
        }

        private void HandleCredits()
        {
            CreateView(_creditsPopUp, CanvasLayer.PopUps);
        }
    }
}