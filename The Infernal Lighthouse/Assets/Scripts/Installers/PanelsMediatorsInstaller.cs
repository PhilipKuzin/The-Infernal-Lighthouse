using UnityEngine;
using Zenject;

public class PanelsMediatorsInstaller : MonoInstaller
{
    [SerializeField] private DefeatPanel _defeatPanel;
    public override void InstallBindings()
    {
        BindDefeatPanel();
        BindDefeatPanelMediator();
    }

    private void BindDefeatPanel()
    {
        Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();
    }

    private void BindDefeatPanelMediator()
    {
        Container.BindInterfacesAndSelfTo<DefeatPanelMediator>().AsSingle();
    }
}
