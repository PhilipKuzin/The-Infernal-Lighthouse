using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private EnemyFactory _enemyFactory;

    private Coroutine _spawnCoroutine;

    public void StartWork ()
    {
        StopWork();
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    public void StopWork()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoroutine ()
    {
        while (true)
        {
            EnemyType selectedType = (EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
            Enemy enemy = _enemyFactory.GetEnemy(selectedType);
            enemy.MoveTo(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
            yield return new  WaitForSeconds (_spawnCooldown);
        }
    }
}
