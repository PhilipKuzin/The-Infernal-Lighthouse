
using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    private int _levelNumber; // добавлено 25.06!

    public void Increase()  // добавлено 25.06!
    {
        _levelNumber++;
        _spawner.SetLevel(_levelNumber);
        _spawner.StartWork();
    }

    private void Awake()
    {
        _spawner.SetLevel(_levelNumber);
        _spawner.StartWork();
    }
}
