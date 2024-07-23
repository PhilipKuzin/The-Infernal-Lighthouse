using System;
using UnityEngine;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private PlayerStats _playerStats;
    private Level _level; 

    private PlayerStatsMediator (Player player, PlayerStats playerStats, Level level) 
    {
        Debug.Log("Создан медиатор playerStats!");
        _player = player;
        _playerStats = playerStats;
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
        _playerStats.ResetView(_player.MaxHealth);
    }

    private void ChangeHealthView()
    {
        _playerStats.ChangeHealthView(_player.CurrentHealth);
        //Debug.Log("Событие изменения здоровья отработало в медиаторе!");
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
        _player.OnDead -= LoseLevel; 
    }
}
