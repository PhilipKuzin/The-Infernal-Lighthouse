using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour, IPauseHandler
{
    [SerializeField] private List<Transform> _spawnPoints;

    private EnemyFactory _enemyFactory;
    private Coroutine _spawnCoroutine;
    private PauseManager _pauseManager;

    private EnemyType _typeByLevel;

    private int _level;
    private float _spawnCooldown;
    private bool _isPaused;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, PauseManager pauseManager)
    {
        _enemyFactory = enemyFactory;
        _pauseManager = pauseManager;

        _pauseManager.Register(this);
    }

    public void StartWork()
    {
        StopWork();
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    public void StopWork()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)  
        {
            while (_isPaused)
            {
                yield return null; 
            }

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
                return _typeByLevel;
            case 1:
                _typeByLevel = EnemyType.ImpEnemy;
                _spawnCooldown = 2.5f;
                return _typeByLevel;
            case 2:
                _typeByLevel = (EnemyType)Random.Range(0, 2);
                _spawnCooldown = 2.5f;
                return _typeByLevel;
            case 3:
                _typeByLevel = (EnemyType)Random.Range(0, 3);
                _spawnCooldown = 1.5f;
                return _typeByLevel;
            default:
                _typeByLevel = (EnemyType)Random.Range(0, 3);
                _spawnCooldown = 1f;
                return _typeByLevel;
        }
    }

    public void SetLevel(int level)
    {
        _level = level;
    }

    public void SetLevelDefeated()
    {
        StopWork(); 
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }
}
