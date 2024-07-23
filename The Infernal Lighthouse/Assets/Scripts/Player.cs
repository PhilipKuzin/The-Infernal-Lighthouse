using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour, IDamageable, IEnemyTarget
{
    public event Action OnHealthChanged;
    public event Action OnDead;
    public event Action OnPlayerReborn;
    public event Action OnPlayerLevelChanged; // äîáàâëåíî 25.06!

    private RaycastAttak _raycastAttack;
    private MovementHandler _movementHandler;

    private const int HealthReduceValue = 10;

    private float _moveSpeed = 5;  // â êà÷åñòâå ïåðêà óâåëè÷èâàåì ìóâ ñïèä ÎÁÄÓÌÀÒÜ ÐÅÀËÈÇÀÖÈÞ
    private int _currentHealth;
    private int _fragsCounter;     // äîáàâëåíî 25.06! ñ÷åò÷èê ôðàãîâ
    private bool _isActive;

    public Vector3 Position => transform.position;
    public int MaxHealth => 20; 

    public bool IsActive
    {
        get { return _isActive; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }

    public int FragsCounter    // äîáàâëåíî 25.06! ñâîéñòâî ñ÷åò÷èêà ôðàãîâ
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
        _raycastAttack.OnEnemyKilled -= IncreaseFragsÑount; // äîáàâëåíî 25.06!
    }

    [Inject]
    private void Construct(MovementHandler movementHandler, RaycastAttak raycastAttak)
    {
        _movementHandler = movementHandler;
        _raycastAttack = raycastAttak;
        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += ClickAction;
        _raycastAttack.OnEnemyKilled += IncreaseFragsÑount;  // äîáàâëåíî 25.06! ïîäïèñêà íà ñîáûòèå ôðàãà
    }

    private void IncreaseFragsÑount()  // äîáàâëåíî 25.06! óâåëè÷åíèå ñ÷åò÷èêà ôðàãîâ è ïðîâåðêà íà ëåâåëÀï ÑÄÅËÀÒÜ ÍÎÐÌÀËÜÍÎ
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

    public void TakeDamage()
    {
        if (CurrentHealth >= HealthReduceValue)
        {
            CurrentHealth -= HealthReduceValue;
            OnHealthChanged?.Invoke();

            if (CurrentHealth <= 0)
            {
                gameObject.SetActive(false);
                _isActive = false;
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
