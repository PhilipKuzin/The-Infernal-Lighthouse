using System;
using UnityEngine;

public class PausePanelMediator : IDisposable
{
    private IInput _input;
    private PauseManager _pauseManager;
    private UIPopUpPausePanel _pausePanel;

    public PausePanelMediator(UIPopUpPausePanel pausePanel, PauseManager pauseManager, IInput input)
    {
        _pauseManager = pauseManager;
        _pausePanel = pausePanel;
        _input = input;

        _input.OnEscapeClicked += DoLogicChangingPause;
        _pausePanel.OnClickedResumeBtn += DoLogicChangingPauseFromResumeBtn;
    }

    public void Dispose()
    {
        _input.OnEscapeClicked -= DoLogicChangingPause;
        _pausePanel.OnClickedResumeBtn -= DoLogicChangingPauseFromResumeBtn;
    }

    private void DoLogicChangingPause(ref bool flag)
    {
        _pauseManager.SetPaused(flag);
        _pausePanel.SetActive(flag);

        flag = !flag;
    }

    private void DoLogicChangingPauseFromResumeBtn(bool flag) // вот тут обдумать событие без делегата на реф
    {
        _pauseManager.SetPaused(flag);
        _pausePanel.SetActive(flag);

        if (_input is DesktopInput desktopInput)
            desktopInput.ResetEscFlag();
    }
}
