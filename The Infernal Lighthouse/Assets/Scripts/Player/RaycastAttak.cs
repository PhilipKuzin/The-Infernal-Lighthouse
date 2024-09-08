using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class RaycastAttak : IPauseHandler
{
    public event Action<RaycastHit> OnEnemyKilled;
    public event Action<RaycastHit> OnMiss;
    public event Action<float> OnReloadStarted;
    public event Action OnReloadFinished;

    private PauseManager _pauseManager;
    private Coroutine _reloadCoroutine;

    private const float ReloadTime = 2f;

    private int _maxRound = 5;
    private int _shotsCount;
    private bool _isReloading = false;
    private bool _isPaused;

    [Inject]
    private void Construct(PauseManager pauseManager)
    {
        _pauseManager = pauseManager;
        _isPaused = _pauseManager.IsPaused;

        _pauseManager.Register(this);
    }

    public void PerformAttack(Vector3 position, int damage)
    {
        if (_isReloading || _isPaused)
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
            StartReload();
        }
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    private void StartReload()
    {
        if (_reloadCoroutine != null)
        {
            CoroutineRunner.StopRoutine(_reloadCoroutine);
        }
        _reloadCoroutine = CoroutineRunner.StartRoutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        _isReloading = true;
        OnReloadStarted?.Invoke(ReloadTime);
        Debug.Log("Перезарядка в процессе!");

        float elapsed = 0f;
        while (elapsed < ReloadTime)
        {
            if (_isPaused)
            {
                yield return null; 
                continue; 
            }

            elapsed += Time.deltaTime; 
            yield return null; 
        }

        _shotsCount = 0;
        _isReloading = false;
        OnReloadFinished?.Invoke();
        Debug.Log("Перезарядка завершена!");
    }
}