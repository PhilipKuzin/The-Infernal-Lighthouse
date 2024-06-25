using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStatsInstaller : MonoInstaller
{
    [SerializeField] private PlayerStats _playerStats;
    public override void InstallBindings()
    {
        BindPlayerStats();
        BindPlayerStatsMediator();
    }

    private void BindPlayerStatsMediator()
    {
        Container.BindInterfacesTo<PlayerStatsMediator>().AsSingle();
    }

    private void BindPlayerStats()
    {
        Container.BindIntefacesAndSelfTo<PlayerStats>().FromInstance(_playerStats).AsSingle();
    }
}
