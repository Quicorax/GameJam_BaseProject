using Services.Runtime.AudioService;
using Services.Runtime.Localization;
using Services.Runtime.RemoteVariables;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInstancer>().To<Instancer>().AsSingle();
        
        Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
        Container.Bind<IRemoteVariablesService>().To<RemoteVariablesService>().AsSingle();
    }
}