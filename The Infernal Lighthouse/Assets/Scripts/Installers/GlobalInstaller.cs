using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }

    private void BindInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.BindInterfacesTo<MobileInput>().AsSingle();
        }
        else
        {
            Container.BindInterfacesTo<DesktopInput>().AsSingle();
        }
        
    }
}
