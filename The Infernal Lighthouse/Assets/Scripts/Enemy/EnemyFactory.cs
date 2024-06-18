using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private EnemyConfig _redEnemy, _greenEnemy, _blueEnemy;

    public Enemy GetEnemy(EnemyType enemyType)
    {
        EnemyConfig config = GetConfigBy(enemyType);
        Enemy instanse = Instantiate(config.Prefab);
        instanse.Initizlize(config.Health, config.Speed);
        return instanse;
    }

    private EnemyConfig GetConfigBy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.RedEnemy:
                return _redEnemy;

            case EnemyType.GreenEnemy:
                return _greenEnemy;

            case EnemyType.BlueEnemy:
                return _blueEnemy;

            default: throw new ArgumentException(nameof(enemyType));
        }
    }
}
