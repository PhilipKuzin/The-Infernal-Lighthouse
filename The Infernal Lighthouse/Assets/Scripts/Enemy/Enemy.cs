using UnityEngine;
using Zenject;
public class Enemy : MonoBehaviour, IDamageable
{
    private IEnemyTarget _target;
    private int _health;
    private float _speed;
    public void Initizlize (int health, float speed)
    {
        _health = health;
        _speed = speed;
    }

    [Inject]
    private void Construct (IEnemyTarget enemyTarget)
    {
        _target = enemyTarget;
        //Debug.Log("маяк прокинулся во врага");
    }

    public void MoveTo (Vector3 position) => transform.position = position;

    public void TakeDamage()
    {
        Debug.Log("Damage applied!");
        Destroy(gameObject);    
    }

    private void Update ()
    {
        Vector3 direction = _target.Position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            return;
        else if (collision.gameObject.CompareTag("Player"))
        {
            Lighthouse lighthouse = collision.gameObject.GetComponent<Lighthouse>();
            lighthouse.TakeDamage();
            Destroy(gameObject); // заменить на дестрой + частицы
        }
    }
}
