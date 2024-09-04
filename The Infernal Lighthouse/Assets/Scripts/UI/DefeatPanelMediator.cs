using System;

public class DefeatPanelMediator : IDisposable 
{
    private Level _level;
    private UIPopUpDefeatPanel _defeatPanel;

    public DefeatPanelMediator(Level level, UIPopUpDefeatPanel defeatPanel)
    {
        _level = level;
        _defeatPanel = defeatPanel;

        _level.OnLevelLost += ShowDefeatPanel;
        _defeatPanel.OnClickRestartBtn += RestartLevel;
    }

    public void Dispose()
    {
        _level.OnLevelLost -= ShowDefeatPanel;
    }

    private void RestartLevel()
    {
        _level.Restart();
        _defeatPanel.HidePanel();
    }

    private void ShowDefeatPanel()
    {
        _defeatPanel.ShowPanel();
    }
}
