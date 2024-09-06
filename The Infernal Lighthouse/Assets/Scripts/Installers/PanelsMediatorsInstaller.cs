using System;
using UnityEngine;
using Zenject;

public class PanelsMediatorsInstaller : MonoInstaller
{
    [SerializeField] private UIPopUpDefeatPanel _defeatPanel;
    [SerializeField] private UIPopUpPausePanel _pausePanel;

    public override void InstallBindings()
    {
        BindDefeatPanel();
        BindDefeatPanelMediator();
        BindPausePanel();
        BindPauseManager();
        BindPausePanelMediator();
    }



    private void BindDefeatPanel()
    {
        Container.BindInterfacesAndSelfTo<UIPopUpDefeatPanel>().FromInstance(_defeatPanel).AsSingle();
    }

    private void BindDefeatPanelMediator()
    {
        Container.BindInterfacesAndSelfTo<DefeatPanelMediator>().AsSingle();
    }

    private void BindPausePanel()
    {
        Container.BindInterfacesAndSelfTo<UIPopUpPausePanel>().FromInstance(_pausePanel).AsSingle();
    }


    private void BindPauseManager()
    {
        Container.BindInterfacesAndSelfTo<PauseManager>().AsSingle();
    }

    private void BindPausePanelMediator()
    {
        Container.BindInterfacesAndSelfTo<PausePanelMediator>().AsSingle();
    }
}
