using System;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private UIWidgetLifeBar _uiWidgetlifeBar;
    private Level _level; 

    private PlayerStatsMediator (Player player, UIWidgetLifeBar uiWidgetLifeBar, Level level) 
    {
        _player = player;
        _uiWidgetlifeBar = uiWidgetLifeBar;
        _level = level;              

        _player.OnHealthChanged += ChangeHealthView;
        _player.OnPlayerReborn += ResetHealthView;
        _player.OnPlayerLevelChanged += IncreaseLevel;
        _player.OnDead += LoseLevel; 
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
        _player.OnPlayerLevelChanged -= IncreaseLevel;
        _player.OnDead -= LoseLevel;
    }

    private void LoseLevel() 
    {
        _level.LoseLevel();
    }

    private void IncreaseLevel() 
    {
        _level.Increase();
    }

    private void ResetHealthView()
    {
        _uiWidgetlifeBar.ResetView(_player.HealthNormalized);
    }

    private void ChangeHealthView()
    {
        if(_player.HealthNormalized < 0)
            _uiWidgetlifeBar.ChangeHealthView(0);
        else
            _uiWidgetlifeBar.ChangeHealthView(_player.HealthNormalized);
    }
}
