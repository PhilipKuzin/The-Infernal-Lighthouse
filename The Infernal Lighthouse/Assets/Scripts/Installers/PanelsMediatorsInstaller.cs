using UnityEngine;
using Zenject;

public class PanelsMediatorsInstaller : MonoInstaller
{
    [SerializeField] private UIPopUpDefeatPanel _defeatPanel;
    public override void InstallBindings()
    {
        BindDefeatPanel();
        BindDefeatPanelMediator();
    }

    private void BindDefeatPanel()
    {
        Container.BindInterfacesAndSelfTo<UIPopUpDefeatPanel>().FromInstance(_defeatPanel).AsSingle();
    }

    private void BindDefeatPanelMediator()
    {
        Container.BindInterfacesAndSelfTo<DefeatPanelMediator>().AsSingle();
    }
}
