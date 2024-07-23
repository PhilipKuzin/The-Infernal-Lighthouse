using UnityEngine;
using Zenject;
public class Enemy : MonoBehaviour, IDamageable
{
    private IEnemyTarget _target;
    private int _health;  // удалить из проекта
    private float _speed;
    private float _speedReduceMultiplier = 0.05f;
    private bool _flag = false;
    private Vector3 _direction;

    public void Initizlize(int health, float speed)
    {
        _health = health;
        _speed = speed;
        _flag = false;
    }

    public void MoveTo(Vector3 position) => transform.position = position;

    public void StopMove ()
    {
        if (_speed > 0)
            _speed -= _speedReduceMultiplier;
        Debug.Log("Уменьшилось на 0.01");
    }

    [Inject]
    private void Construct (IEnemyTarget enemyTarget)
    {
        _target = enemyTarget;
    }

    public void TakeDamage()
    {
        Debug.Log("Damage applied!");
        Destroy(gameObject);    
    }

    private void Update ()
    {
        _direction = _target.Position - transform.position;
        transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);

        if (_target.IsActive == false)
        {
            Debug.Log("Стоп МУВ отрабатывает, таргет фолс");
            StopMove();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            return;
        else if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable player = collision.gameObject.GetComponent<IDamageable>();
            player.TakeDamage();
            Destroy(gameObject);
        }
    }
}
