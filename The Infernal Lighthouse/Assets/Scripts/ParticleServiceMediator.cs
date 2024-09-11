using System;
using UnityEngine;

public class ParticleServiceMediator : IDisposable
{
    private Player _player;
    private RaycastAttak _raycastAttack;
    private ParticleService _particleService;

    public ParticleServiceMediator(Player player, RaycastAttak raycastAttak, ParticleService particleService)
    {
        _player = player;
        _particleService = particleService;
        _raycastAttack = raycastAttak;

        _player.OnHealthChanged += DoHealthChangeAction;
        _raycastAttack.OnEnemyKilled += DoEnemyKillAction;
        _raycastAttack.OnMissed += DoMissAction;
    }

    public void Dispose()
    {
        _player.OnHealthChanged -= DoHealthChangeAction;
        _raycastAttack.OnEnemyKilled -= DoEnemyKillAction;
        _raycastAttack.OnMissed -= DoMissAction;
    }

    private void DoMissAction(RaycastHit hitInfo)
    {
        _particleService.SpawnParticleEffectMiss(hitInfo);
    }

    private void DoEnemyKillAction(RaycastHit hitInfo)
    {
        _particleService.SpawnParticleEffectExplosion(hitInfo);
    }

    private void DoHealthChangeAction()
    {
        _particleService.SpawnParticleEffectPlayerExplosion(_player.transform.position);
    }
}
