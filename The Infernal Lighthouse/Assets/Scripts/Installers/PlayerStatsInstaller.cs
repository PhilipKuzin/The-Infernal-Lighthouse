using UnityEngine;
using Zenject;

public class PlayerStatsInstaller : MonoInstaller
{
    [SerializeField] private UIWidgetLifeBar _uiWidgetLifeBar;
    [SerializeField] private Level _level;

    public override void InstallBindings()
    {
        BindWidgetLifeBar();
        BindLevel();
        BindPlayerStatsMediator();
    }

    private void BindWidgetLifeBar()
    {
        Container.BindIntefacesAndSelfTo<UIWidgetLifeBar>().FromInstance(_uiWidgetLifeBar).AsSingle();
    }

    private void BindLevel()
    {
        Container.BindInterfacesAndSelfTo<Level>().FromInstance(_level).AsSingle();
    }

    private void BindPlayerStatsMediator()
    {
        Container.BindInterfacesTo<PlayerStatsMediator>().AsSingle();
    }
}
