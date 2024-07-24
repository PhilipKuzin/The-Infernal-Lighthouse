using System;
using UnityEngine;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private PlayerStatsPanel _playerStatsPanel;
    private Level _level; 

    private PlayerStatsMediator (Player player, PlayerStatsPanel playerStatsPanel, Level level) 
    {
        Debug.Log("������ �������� playerStats!");
        _player = player;
        _playerStatsPanel = playerStatsPanel;
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
        _playerStatsPanel.ResetView(_player.MaxHealth);
    }

    private void ChangeHealthView()
    {
        _playerStatsPanel.ChangeHealthView(_player.CurrentHealth);
        //Debug.Log("������� ��������� �������� ���������� � ���������!");
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
        _player.OnDead -= LoseLevel; 
    }
}
