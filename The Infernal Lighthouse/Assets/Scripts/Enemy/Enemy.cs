using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageable
{
    public event Action OnEnemyStoped;

    private IEnemyTarget _target;
    private Vector3 _direction;


    private int _damage;
    private int _health;
    private int _currentHealth;
    private float _speed;
    private float _speedReduceMultiplier = 0.25f;

    private void Update()
    {
        _direction = _target.Position - transform.position;
        transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);

        if (_target.IsActive == false)
            StopMoveProcess();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable player = collision.gameObject.GetComponent<IDamageable>();
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    [Inject]
    private void Construct(IEnemyTarget enemyTarget)
    {
        _target = enemyTarget;
    }

    public void Initizlize(int health, float speed, int damage)
    {
        _health = health;
        _speed = speed;
        _damage = damage;

        _currentHealth = health;
    }

    public void MoveTo(Vector3 position) => transform.position = position;

    public void RotateTo()
    {
        transform.LookAt(_target.Position);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage applied!");
        _currentHealth -= damage;

        if ( _currentHealth <= 0 )
            Destroy(gameObject);
    }

    public void StopMoveProcess()
    {
        if (_speed > 0)
            _speed -= _speedReduceMultiplier;
        else if (_speed <= 0)
        {
            _speed = 0;
            OnEnemyStoped?.Invoke();
        }
    }

}
