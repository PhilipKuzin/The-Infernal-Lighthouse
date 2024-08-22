using System;
using UnityEngine;

public class RaycastAttak
{
    public event Action<RaycastHit> OnEnemyKilled;    
    public event Action<RaycastHit> OnMiss;

    public void PerformAttack(Vector3 position)  // потенциально добавляем флаг разброса (дробовик) и дополняем логику примером от night train code 
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable enemy) && enemy is Enemy realEnemy)
            {
                OnEnemyKilled?.Invoke(hitInfo);
                realEnemy.TakeDamage();
            }
            else
            {
                OnMiss?.Invoke(hitInfo);
            }
        }
    }
}
