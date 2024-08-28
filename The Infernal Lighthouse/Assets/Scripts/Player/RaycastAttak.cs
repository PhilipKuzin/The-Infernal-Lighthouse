using System;
using System.Collections;
using UnityEngine;

public class RaycastAttak
{
    public event Action<RaycastHit> OnEnemyKilled;
    public event Action<RaycastHit> OnMiss;
    public event Action<float> OnReloadStarted;
    public event Action OnReloadFinished;

    private const float ReloadTime = 3f;

    private int _maxRound = 5;
    private int _shotsCount;
    private bool _isReloading = false;

    public void PerformAttack(Vector3 position, int damage)
    {
        if (_isReloading != false)
            return;

        _shotsCount++;

        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable entity) && entity is Enemy realEnemy)
            {
                OnEnemyKilled?.Invoke(hitInfo);
                realEnemy.TakeDamage(damage);
            }
            else
            {
                OnMiss?.Invoke(hitInfo);
            }
        }

        if (_shotsCount >= _maxRound)
        {
            CoroutineRunner.StartRoutine(ReloadCoroutine());
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        _isReloading = true;
        OnReloadStarted?.Invoke(ReloadTime);
        Debug.Log("Перезарядка в процессе!");

        yield return new WaitForSeconds(ReloadTime);

        _shotsCount = 0;
        _isReloading = false;
        OnReloadFinished?.Invoke();
        Debug.Log("Перезарядка завершена!");
    }

}