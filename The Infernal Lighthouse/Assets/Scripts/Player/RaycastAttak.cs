using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttak 
{
    public event Action OnEnemyKilled;      // ��������� 25.06! ������� �������� �����

    private ParticleService _particleService;

    public RaycastAttak(ParticleService particleService)
    {
        _particleService = particleService;
    }

    public void PerformAttack(Vector3 position)  // ������������ ��������� ���� �������� (��������) � ��������� ������ �������� �� night train code 
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable enemy) && enemy is Enemy realEnemy) // �������� �� ����� ���������� ��-�� ���� ��� ���� ���� IDamageable (��������!) �������� IS ? 
            {
                OnEnemyKilled?.Invoke();                            // ��������� 25.06! ����� ������� �������� �����! 
                _particleService.SpawnParticleEffectExplosion(hitInfo);
                realEnemy.TakeDamage();
            }
            else
            {
                _particleService.SpawnParticleEffectMiss(hitInfo);
            }
        }
    }
}
