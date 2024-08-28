using System;
using System.IO;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private const string ConfigsPath = "Enemies";
    private const string ImpEnemyConfig = "ImpConfig";
    private const string BlueEnemyConfig = "BlueEnemy";
    private const string FlameEnemyConfig = "FlameConfig";

    private EnemyConfig _impEnemy, _flameEnemy, _blueEnemy;
    private DiContainer _container;

    public EnemyFactory(DiContainer container)
    {
        _container = container;
        Load();
    }

    public Enemy GetEnemy(EnemyType enemyType)
    {
        EnemyConfig config = GetConfigBy(enemyType);
        Enemy instanñe = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);

        instanñe.Initizlize(config.Health, config.Speed, config.Damage);

        EnemyVisual visual = instanñe.GetComponent<EnemyVisual>();
        EnemyMediator mediator = new EnemyMediator (instanñe, visual);
        return instanñe;
    }


    private EnemyConfig GetConfigBy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.RedEnemy:
                return _impEnemy;

            case EnemyType.GreenEnemy:
                return _flameEnemy;

            case EnemyType.BlueEnemy:
                return _blueEnemy;

            default: throw new ArgumentException(nameof(enemyType));
        }
    }

    private void Load ()
    {
        _impEnemy = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, ImpEnemyConfig)); 
        _flameEnemy = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, FlameEnemyConfig));
        _blueEnemy = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, BlueEnemyConfig));
    }
}
