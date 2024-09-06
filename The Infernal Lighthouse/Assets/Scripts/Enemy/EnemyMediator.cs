using System;
using UnityEngine;

public class EnemyMediator : IDisposable
{
    private Enemy _enemy;
    private EnemyVisual _visual;

    public EnemyMediator(Enemy enemy, EnemyVisual visual)
    {
        _enemy = enemy;
        _visual = visual;

        _enemy.OnEnemyStoped += DoStopAnimation;
        _enemy.OnEnemyStoppedByPause += ChangeAnimationSpeed;
    }

    private void ChangeAnimationSpeed(bool isPaused)
    {
        if (_visual != null)
            _visual.StopAnimationSpeed(isPaused);
    }

    public void Dispose()
    {
        _enemy.OnEnemyStoped -= DoStopAnimation;
        _enemy.OnEnemyStoppedByPause -= ChangeAnimationSpeed;
    }

    private void DoStopAnimation()
    {
        _visual.StopAnimation();
    }
}
