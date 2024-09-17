using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private ParticleService _particleService;

    public override void InstallBindings()
    {
        BindParticleService();
        BindRaycastAttack();
        BindPlayer();
        BindParticleServiceMediator();
    }

    private void BindParticleService()
    {
        ParticleService particleService = Container.InstantiatePrefabForComponent<ParticleService>(_particleService, new Vector3(0, 0, 0), Quaternion.identity, null);
        Container.BindIntefacesAndSelfTo<ParticleService>().FromInstance(particleService).AsSingle();
    }

    private void BindRaycastAttack()
    {
        Container.BindIntefacesAndSelfTo<RaycastAttak>().AsSingle().NonLazy();  // 22.08
    }

    private void BindPlayer()
    {
        // Поворот, который нужно применить, чтобы ось Z объекта указывала вверх
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);

        // Инстанциируем игрока с нужной ориентацией
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint.position, rotation, null);

        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }

    private void BindParticleServiceMediator()
    {
        Container.BindInterfacesAndSelfTo<ParticleServiceMediator>().AsSingle();
    }
}
