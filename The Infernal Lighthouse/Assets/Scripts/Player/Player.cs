using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Player : MonoBehaviour, IDamageable, IEnemyTarget, IPauseHandler
{
    public event Action OnHealthChanged;
    public event Action OnDead;
    public event Action OnPlayerReborn;
    public event Action OnPlayerLevelChanged;

    private RaycastAttak _raycastAttack;
    private MovementHandler _movementHandler;
    private PauseManager _pauseManager;

    private float _moveSpeed = 5;
    private int _currentHealth;
    private int _damage = 1;
    private int _fragsCounter = 0;
    private int _comparator = 1;
    private int _comparatorMultiplier = 2;

    private bool _isActive;
    private bool _isPaused;

    public Vector3 Position => transform.position;
    public int MaxHealth => 10;
    public float HealthNormalized => (float)_currentHealth / MaxHealth;

    public bool IsActive
    {
        get { return _isActive; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }

    public int FragsCounter
    {
        get { return _fragsCounter; }
        private set { _fragsCounter = value; }
    }

    private void Start()
    {
        Reborn();
    }

    private void OnDisable()
    {
        _movementHandler.OnMove -= LookOnCursor;
        _movementHandler.OnClicked -= ClickAction;
        _raycastAttack.OnEnemyKilled -= IncreaseFragsСount;
    }

    private void OnDestroy()
    {
        DOTween.KillAll(true);
    }

    [Inject]
    private void Construct(MovementHandler movementHandler, RaycastAttak raycastAttak, PauseManager pauseManager)
    {
        _movementHandler = movementHandler;
        _raycastAttack = raycastAttak;
        _pauseManager = pauseManager;
        _isPaused = _pauseManager.IsPaused;

        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += ClickAction;
        _raycastAttack.OnEnemyKilled += IncreaseFragsСount;

        _pauseManager.Register(this);
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }

    public void Reborn()
    {
        CurrentHealth = MaxHealth;
        _isActive = true;
        _raycastAttack.SetStartedAmmoAmount();
        OnPlayerReborn?.Invoke();
    }

    public void TakeDamage(int inputDamage)
    {
        if (Camera.main.transform != null)
            Camera.main.DOShakePosition(1, 0.6f);

        CurrentHealth -= inputDamage;

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            _isActive = false;
            OnHealthChanged?.Invoke();
            OnDead?.Invoke();
            return;
        }

        OnHealthChanged?.Invoke();
    }

    private void IncreaseFragsСount(RaycastHit hitInfo)
    {
        FragsCounter++;

        if (FragsCounter % _comparator == 0)
        {
            _comparator += _comparatorMultiplier;
            FragsCounter = 0;
            OnPlayerLevelChanged?.Invoke();
            Debug.Log("LEVEL UP");
        }
    }

    private void ClickAction(Vector3 position)
    {
        if (_isPaused == true)
            return;

        _raycastAttack.PerformAttack(position, _damage);
    }

    private void LookOnCursor(Vector3 position)
    {
        if (_isPaused)
            return;

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (playerPlane.Raycast(ray, out float hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            // Вычисляем направление к целевой точке
            Vector3 direction = targetPoint - transform.position;

            // Убираем компонент Y из направления, чтобы вращение было только в горизонтальной плоскости
            direction.y = 0;

            // Проверяем, что направление не нулевое
            if (direction.sqrMagnitude > 0)
            {
                // Создаем кватернион для поворота
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                // Применяем дополнительный поворот на -90 градусов вокруг оси X
                targetRotation *= Quaternion.Euler(-90, 0, 0);
                // Плавно вращаем объект
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _moveSpeed * Time.deltaTime);
            }
        }
    }
}
