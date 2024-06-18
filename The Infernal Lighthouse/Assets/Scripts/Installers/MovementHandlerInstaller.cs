using System;
using UnityEngine;
using Zenject;

public class MovementHandlerInstaller : MonoInstaller
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
