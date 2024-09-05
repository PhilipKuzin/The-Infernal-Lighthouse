using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;

    private EnemyFactory _enemyFactory;
    private Coroutine _spawnCoroutine;
    private EnemyType _typeByLevel;

    private int _level;
    private float _spawnCooldown; // ËÁÏÂÌÂÌÓ 25.06!

    [Inject]
    private void Construct(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    public void StartWork()
    {
        StopWork();
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void StopWork()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)  
        {
            EnemyType selectedType = SetSpawnerModeBy(_level);
            Enemy enemy = _enemyFactory.GetEnemy(selectedType);
            enemy.MoveTo(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
            enemy.RotateTo();
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    public EnemyType SetSpawnerModeBy(int level)  
    {
        switch (level)
        {
            case 0:
                _typeByLevel = EnemyType.ImpEnemy;
                _spawnCooldown = 4;
                //Debug.Log("”–Œ¬≈Õ‹ 0");
                return _typeByLevel;
            case 1:
                //_typeByLevel = EnemyType.ImpEnemy;
                _typeByLevel = (EnemyType)Random.Range(0, 2);
                _spawnCooldown = 2.5f;
                //Debug.Log("”–Œ¬≈Õ‹ 1");
                return _typeByLevel;
            case 2:
                _typeByLevel = (EnemyType)Random.Range(0, 2);
                _spawnCooldown = 2;
                //Debug.Log("”–Œ¬≈Õ‹ 2");
                return _typeByLevel;
            case 3:
                _typeByLevel = (EnemyType)Random.Range(0, 3);
                _spawnCooldown = 1;
                //Debug.Log("”–Œ¬≈Õ‹ 3");
                return _typeByLevel;
            default:
                _typeByLevel = (EnemyType)Random.Range(0, 3);
                _spawnCooldown = 0.8f;
                return _typeByLevel;
        }
    }

    public void SetLevel(int level)
    {
        _level = level;
    }

    public void SetLevelDefeated()
    {
        StopWork(); // 22 07
    }
}
