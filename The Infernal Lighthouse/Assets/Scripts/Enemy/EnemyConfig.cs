using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfigs/Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField, Range(1, 10)] private int _health;
    [SerializeField, Range(1, 15)] private float _speed;
    [SerializeField, Range(1, 30)] private int _damage;

    public Enemy Prefab => _prefab;
    public int Health => _health;
    public float Speed => _speed;
    public int Damage => _damage;


}
