using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour, IDamageable, IEnemyTarget
{
    public event Action OnHealthChanged;
    public event Action OnDead;
    public event Action OnPlayerReborn;
    public event Action OnPlayerLevelChanged;

    private RaycastAttak _raycastAttack;
    private MovementHandler _movementHandler;

    private float _moveSpeed = 5;
    private int _currentHealth;
    private int _damage = 1; // ÈÑÏĞÀÂÈÒÜ
    private int _fragsCounter;     
    private bool _isActive;


    public Vector3 Position => transform.position;
    public int MaxHealth => 100;
    public float HealthNormalized => (float) _currentHealth / MaxHealth;

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
        _raycastAttack.OnEnemyKilled -= IncreaseFragsÑount; 
    }

    [Inject]
    private void Construct(MovementHandler movementHandler, RaycastAttak raycastAttak)
    {
        _movementHandler = movementHandler;
        _raycastAttack = raycastAttak;
        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += ClickAction;
        _raycastAttack.OnEnemyKilled += IncreaseFragsÑount;  
    }

    private void IncreaseFragsÑount(RaycastHit hitInfo)  // äîáàâëåíî 25.06! óâåëè÷åíèå ñ÷åò÷èêà ôğàãîâ è ïğîâåğêà íà ëåâåëÀï ÑÄÅËÀÒÜ ÍÎĞÌÀËÜÍÎ
                                                         // ïåğåäàåòñÿ íåíóæíûé ïàğàìåòğ, ïîäóìàòü êàê èñïğàâèòü
    {
        FragsCounter++;

        if (FragsCounter % 10 == 0)
        {
            OnPlayerLevelChanged?.Invoke();
            Debug.Log("LEVEL UP");
        }
    }

    public void Reborn()
    {
        CurrentHealth = MaxHealth;
        _isActive = true;
        OnPlayerReborn?.Invoke();
    }

    public void TakeDamage(int inputDamage)
    {
        if (CurrentHealth >= inputDamage)
        {
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
    }

    private void ClickAction(Vector3 position)
    {
        _raycastAttack.PerformAttack(position, _damage);
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
