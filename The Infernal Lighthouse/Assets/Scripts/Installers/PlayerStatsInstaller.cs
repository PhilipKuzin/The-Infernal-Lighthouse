using UnityEngine;
using Zenject;

public class PlayerStatsInstaller : MonoInstaller
{
    [SerializeField] private PlayerStatsPanel _playerStats;
    [SerializeField] private Level _level;

    public override void InstallBindings()
    {
        BindPlayerStats();
        BindLevel();
        BindPlayerStatsMediator();
    }

    private void BindPlayerStats()
    {
        Container.BindIntefacesAndSelfTo<PlayerStatsPanel>().FromInstance(_playerStats).AsSingle();
    }

    private void BindLevel()
    {
        Container.BindInterfacesAndSelfTo<Level>().FromInstance(_level).AsSingle();
    }

    private void BindPlayerStatsMediator()
    {
        Container.BindInterfacesTo<PlayerStatsMediator>().AsSingle();
    }
}
