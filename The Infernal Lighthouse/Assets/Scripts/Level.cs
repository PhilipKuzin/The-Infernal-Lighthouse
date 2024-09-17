using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    public event Action OnLevelLost;
    public event Action OnLevelStarted;

    private int _levelNumber;

    private void Start() 
    {
        Invoke("Restart", 4f);
        //Restart();
    }

    public void Restart()
    {
        OnLevelStarted?.Invoke();
        _spawner.SetLevel(_levelNumber);
        _spawner.StopWork();
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
        _spawner.StopWork(); 
        OnLevelLost?.Invoke();
    }

}

