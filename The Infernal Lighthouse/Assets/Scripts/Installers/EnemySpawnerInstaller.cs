using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFactory();
    }

    private void BindFactory()
    {
        Container.BindIntefacesAndSelfTo<EnemyFactory>().AsSingle(); ;
    }
}
