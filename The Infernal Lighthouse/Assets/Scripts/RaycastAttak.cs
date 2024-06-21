using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttak 
{
    private ParticleService _particleService;

    public RaycastAttak(ParticleService particleService)
    {
        _particleService = particleService;
    }

    public void PerformAttack(Vector3 position)  // потенциально добавляем флаг разброса (дробовик) и дополняем логику примером от night train code 
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable enemy))
            {
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
