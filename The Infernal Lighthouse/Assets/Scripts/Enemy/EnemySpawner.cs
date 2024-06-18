using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    private EnemyFactory _enemyFactory;

    private Coroutine _spawnCoroutine;

    [Inject]
    private void Construct (EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        Debug.Log("Фабрика прокинута в спавнер");
    }

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
