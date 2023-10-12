using Services.Runtime.AudioService;
using Services.Runtime.Localization;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
    }
}