using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindMovementHandler();
    }

    private void BindMovementHandler()
    {
        Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle();
    }
}
