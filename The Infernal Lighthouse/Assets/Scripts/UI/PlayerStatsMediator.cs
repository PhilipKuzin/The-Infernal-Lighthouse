using System;
using UnityEngine;
using Zenject;

public class PlayerStatsMediator : IDisposable
{
    private Player _player;
    private PlayerStats _playerStats;

    // ���������� ���� �������� ����� ����������� ���������� ������ ������ � ������������� ��� enemyType selectedType ����� level (����������� ���� Level) 
    
    private PlayerStatsMediator (Player player, PlayerStats playerStats)
    {
        Debug.Log("������ �������� playerStats!");
        _player = player;
        _playerStats = playerStats;

        _player.OnHealthChanged += ChangeHealthView;
        _player.OnPlayerReborn += ResetHealthView;
    }

    private void ResetHealthView()
    {
        _playerStats.ResetView(_player.MaxHealth);
    }

    private void ChangeHealthView()
    {
        _playerStats.ChangeHealthView(_player.CurrentHealth);
        Debug.Log("������� ��������� �������� ���������� � ���������!");
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= ChangeHealthView;
        _player.OnPlayerReborn -= ResetHealthView;
    }
}
