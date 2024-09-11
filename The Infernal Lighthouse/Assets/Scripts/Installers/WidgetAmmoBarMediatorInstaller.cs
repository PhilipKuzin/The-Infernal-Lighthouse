using UnityEngine;
using Zenject;

public class WidgetAmmoBarMediatorInstaller : MonoInstaller
{
    [SerializeField] private UIWidgetAmmoBar _uiWidgetAmmoBar;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UIWidgetAmmoBar>().FromInstance(_uiWidgetAmmoBar).AsSingle();
        Container.BindInterfacesAndSelfTo<WidgetAmmoBarMediator>().AsSingle();
    }
}
