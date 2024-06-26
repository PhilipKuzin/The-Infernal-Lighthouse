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

            if (hitCollider.TryGetComponent(out IDamageable enemy)) // �������� �� ����� ���������� ��-�� ���� ��� ���� ���� IDamageable (��������!) �������� IS ? 
            {
                OnEnemyKilled?.Invoke();                            // ��������� 25.06! ����� ������� �������� �����! 
                _particleService.SpawnParticleEffectOnHit(hitInfo);
                enemy.TakeDamage();
            }
            else
            {
                _particleService.SpawnParticleEffectOnMiss(hitInfo);
            }
        }
    }
}
