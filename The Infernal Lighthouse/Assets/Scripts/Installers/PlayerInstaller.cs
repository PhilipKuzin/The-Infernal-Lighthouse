using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _lightHouseSpawnPoint;
    [SerializeField] private Lighthouse _lightHousePrefab;

    public override void InstallBindings()
    {
        BindLighhouse();
    }

    private void BindLighhouse()
    {
        Lighthouse lightHouse = Container.InstantiatePrefabForComponent<Lighthouse>(_lightHousePrefab, _lightHouseSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Lighthouse>().FromInstance(lightHouse).AsSingle();
    }
}
