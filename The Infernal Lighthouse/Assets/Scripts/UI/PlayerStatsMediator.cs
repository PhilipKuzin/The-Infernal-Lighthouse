using System;
using UnityEngine;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private PlayerStats _playerStats;
    private Level _level; 

    private PlayerStatsMediator (Player player, PlayerStats playerStats, Level level) 
    {
        Debug.Log("������ �������� playerStats!");
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
        // �������� �������� ������ ������ �� ������? 
    }

    private void ResetHealthView()
    {
        _playerStats.ResetView(_player.MaxHealth);
    }

    private void ChangeHealthView()
    {
        _playerStats.ChangeHealthView(_player.CurrentHealth);
        //Debug.Log("������� ��������� �������� ���������� � ���������!");
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
        _player.OnDead -= LoseLevel; 
    }
}
