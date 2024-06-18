using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }
}
