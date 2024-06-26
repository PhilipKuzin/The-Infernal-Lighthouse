using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleService : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private ParticleSystem _missParticles;

    private float _hitEffectDestroyDelay = 2;

    public void SpawnParticleEffectOnHit(RaycastHit hitInfo)
    {

        var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var hitEffect = Instantiate(_hitParticles, hitInfo.point, hitEffectRotation);

        Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
    }

    public void SpawnParticleEffectOnMiss(RaycastHit hitInfo)
    {
        var missEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var missEffect = Instantiate(_missParticles, hitInfo.point, missEffectRotation);

        Destroy(missEffect.gameObject, _hitEffectDestroyDelay);
    }
}
