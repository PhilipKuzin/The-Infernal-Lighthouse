using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour, IDamageable, IEnemyTarget
{
    public event Action OnHealthChanged;
    public event Action OnDead;
    public event Action OnPlayerReborn;
    // добавл€ем событие изменени€ количества фрагов игрока (каждые 10 ?) 
    // добавл€ем счетчик фрагов 

    private RaycastAttak _raycastAttack;
    private MovementHandler _movementHandler;

    private const int HealthReduceValue = 10;
    private float _moveSpeed = 10;  // в качестве перка увеличиваем мув спид ќЅƒ”ћј“№ –≈јЋ»«ј÷»ё
    private int _currentHealth;

    public Vector3 Position => transform.position;
    public int MaxHealth => 100;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }

    private void Start()
    {
        Reborn();
    }

    [Inject]
    private void Construct(MovementHandler movementHandler, RaycastAttak raycastAttak)
    {
        _movementHandler = movementHandler;
        _raycastAttack = raycastAttak;
        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += ClickAction;
    }

    public void Reborn()
    {
        CurrentHealth = MaxHealth;
        OnPlayerReborn?.Invoke();
    }

    public void TakeDamage()
    {

        if (CurrentHealth >= HealthReduceValue)
        {
            CurrentHealth -= HealthReduceValue;
            OnHealthChanged?.Invoke();

            if (CurrentHealth <= 0)
            {
                OnHealthChanged?.Invoke();
                OnDead?.Invoke();
            }
        }
    }

    private void ClickAction(Vector3 position)
    {
        _raycastAttack.PerformAttack(position);
    }

    private void LookOnCursor(Vector3 position)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (playerPlane.Raycast(ray, out float hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _moveSpeed * Time.deltaTime);
        }
    }
}
