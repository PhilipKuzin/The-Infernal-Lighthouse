using Zenject;

public class GameSaverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameResultSaver>().AsSingle();
    }
}
