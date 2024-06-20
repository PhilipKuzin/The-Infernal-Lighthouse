using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _lightHouseSpawnPoint;
    [SerializeField] private Lighthouse _lightHousePrefab;
    [SerializeField] private RaycastAttak _raycastAttackPrefab;

    public override void InstallBindings()
    {
        BindRaycastAttack();
        BindLighhouse();
    }

    private void BindRaycastAttack()
    {
        RaycastAttak raycastAttak = Container.InstantiatePrefabForComponent<RaycastAttak>(_raycastAttackPrefab, new Vector3(0, 0, 0), Quaternion.identity, null);
        Container.Bind<RaycastAttak>().FromInstance(raycastAttak).AsSingle();
    }

    private void BindLighhouse()
    {
        Lighthouse lightHouse = Container.InstantiatePrefabForComponent<Lighthouse>(_lightHousePrefab, _lightHouseSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Lighthouse>().FromInstance(lightHouse).AsSingle();
    }
}
