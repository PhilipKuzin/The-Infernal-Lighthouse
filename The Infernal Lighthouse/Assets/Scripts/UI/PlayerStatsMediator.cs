using System;
using UnityEngine;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private UIWidgetLifeBar _uiWidgetlifeBar;
    private Level _level; 

    private PlayerStatsMediator (Player player, UIWidgetLifeBar uiWidgetLifeBar, Level level) 
    {
        Debug.Log("Создан медиатор playerStats!");
        _player = player;
        _uiWidgetlifeBar = uiWidgetLifeBar;
        _level = level;              

        _player.OnHealthChanged += ChangeHealthView;
        _player.OnPlayerReborn += ResetHealthView;
        _player.OnPlayerLevelChanged += IncreaseLevel;
        _player.OnDead += LoseLevel; 
    }

    private void LoseLevel() 
    {
        _level.LoseLevel();
    }

    private void IncreaseLevel() 
    {
        _level.Increase();
        // добавить анимацию нового уровня на экране? 
    }

    private void ResetHealthView()
    {
        _uiWidgetlifeBar.ResetView(_player.MaxHealth);
    }

    private void ChangeHealthView()
    {
        _uiWidgetlifeBar.ChangeHealthView(_player.HealthNormalized);
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
        _player.OnDead -= LoseLevel; 
    }
}
