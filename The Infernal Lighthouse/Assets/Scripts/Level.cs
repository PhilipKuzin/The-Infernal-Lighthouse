using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    public event Action OnLevelLost;

    private int _levelNumber; 

    private void Awake()
    {
        Restart();
    }

    public void Restart()
    {
        _spawner.SetLevel(_levelNumber);
        _spawner.SetLevelDefeated();
        _spawner.StartWork();
    }

    public void Increase()
    {
        _levelNumber++;
        _spawner.SetLevel(_levelNumber);
        _spawner.StartWork();
    }

    public void LoseLevel()
    {
        _spawner.SetLevelDefeated(); 
        OnLevelLost?.Invoke();
    }

}
