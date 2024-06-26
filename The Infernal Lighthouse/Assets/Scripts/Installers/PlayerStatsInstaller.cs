using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStatsInstaller : MonoInstaller
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Level _level;
    public override void InstallBindings()
    {
        BindPlayerStats();
        BindLevel();
        BindPlayerStatsMediator();
    }

    private void BindLevel()
    {
        Container.BindInterfacesAndSelfTo<Level>().FromInstance(_level).AsSingle();
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
