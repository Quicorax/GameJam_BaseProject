using UnityEngine;
using UnityEngine.UI;

namespace UI.Canvas
{
    public class GameCanvas : BaseCanvas
    {
        [SerializeField] private Button _settingsButton;
        
        [SerializeField] private BaseView _settingsPopUp;
        
        protected override void Awake()
        {
            _settingsButton.onClick.AddListener(HandleSettings);
            base.Awake();
        }

        protected override void OnDestroy()
        {
            _settingsButton.onClick.RemoveAllListeners();
            base.OnDestroy();
        }


        private void HandleSettings()
        {
           var view = CreateView(_settingsPopUp, CanvasLayer.PopUps) as GameSettingsPopUp;
           view.InjectDependencies(NavigateToScene);
        }
    }
}