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
    }

    public void Dispose()
    {
        _enemy.OnEnemyStoped -= DoStopAnimation;
    }

    private void DoStopAnimation()
    {
        _visual.StopAnimation();
    }
}
