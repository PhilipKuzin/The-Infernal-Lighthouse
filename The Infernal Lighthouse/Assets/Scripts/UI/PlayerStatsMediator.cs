using System;
using UnityEngine;
using Zenject;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private PlayerStats _playerStats;
    private Level _level; // добавлено 25.06!

    private PlayerStatsMediator (Player player, PlayerStats playerStats, Level level) 
    {
        Debug.Log("—оздан медиатор playerStats!");
        _player = player;
        _playerStats = playerStats;
        _level = level;              // добавлено 25.06!

        _player.OnHealthChanged += ChangeHealthView;
        _player.OnPlayerReborn += ResetHealthView;
        _player.OnPlayerLevelChanged += IncreaseLevel;
    }

    private void IncreaseLevel() // добавлено 25.06!
    {
        _level.Increase();
        // добавить анимацию нового уровн€ на экране? 
    }

    private void ResetHealthView()
    {
        _playerStats.ResetView(_player.MaxHealth);
    }

    private void ChangeHealthView()
    {
        _playerStats.ChangeHealthView(_player.CurrentHealth);
        Debug.Log("—обытие изменени€ здоровь€ отработало в медиаторе!");
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
    }
}
