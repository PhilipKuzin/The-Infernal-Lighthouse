using UnityEngine;
public class Enemy : MonoBehaviour
{
    private int _health;
    private float _speed;

    public void Initizlize (int health, float speed)
    {
        _health = health;
        _speed = speed;
    }

    public void MoveTo (Vector3 position) => transform.position = position;

    public void TakeDamage()
    {
        Debug.Log("Damage applied!");
        Destroy (gameObject);
    }
}
