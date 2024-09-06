using System;
using System.Collections;
using System.Collections.Generic;
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
        _pausePanel.OnClickedResumeBtn += DoLogicChangingPause;
    }

    private void DoLogicChangingPause(bool flag)
    {
        _pauseManager.SetPaused(flag);
        _pausePanel.SetActive(flag);
    }

    public void Dispose()
    {
        _input.OnEscapeClicked -= DoLogicChangingPause;
        _pausePanel.OnClickedResumeBtn -= DoLogicChangingPause;
    }
}
