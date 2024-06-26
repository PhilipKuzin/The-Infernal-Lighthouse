using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttak 
{
    public event Action OnEnemyKilled;      // добавлено 25.06! событие убийства врага

    private ParticleService _particleService;

    public RaycastAttak(ParticleService particleService)
    {
        _particleService = particleService;
    }

    public void PerformAttack(Vector3 position)  // потенциально добавл€ем флаг разброса (дробовик) и дополн€ем логику примером от night train code 
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable enemy)) // партиклы на ма€ке по€вл€ютс€ из-за того что ма€к тоже IDamageable (ѕќƒ”ћј“№!) проверка IS ? 
            {
                OnEnemyKilled?.Invoke();                            // добавлено 25.06! вызов событи€ убийства врага! 
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
