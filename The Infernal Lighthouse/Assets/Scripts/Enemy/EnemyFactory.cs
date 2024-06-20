using System;
using System.IO;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private const string ConfigsPath = "Enemies";
    private const string RedEnemyConfig = "RedEnemy";
    private const string BlueEnemyConfig = "BlueEnemy";
    private const string GreenEnemyConfig = "GreenEnemy";

    private EnemyConfig _redEnemy, _greenEnemy, _blueEnemy;
    private DiContainer _container;

    public EnemyFactory(DiContainer container)
    {
        _container = container;
        Load();
    }

    public Enemy GetEnemy(EnemyType enemyType)
    {
        //Debug.Log("Запустился гет энеми");
        EnemyConfig config = GetConfigBy(enemyType);
        Enemy instanse = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
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

    private void Load ()
    {
        _redEnemy = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, RedEnemyConfig)); 
        _greenEnemy = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, GreenEnemyConfig));
        _blueEnemy = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, BlueEnemyConfig));
    }
}
