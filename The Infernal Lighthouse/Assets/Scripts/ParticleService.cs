using UnityEngine;

public class ParticleService : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private ParticleSystem _missParticles;
    [SerializeField] private ParticleSystem _playerHitParticles;

    private float _hitEffectDestroyDelay = 2;

    public void SpawnParticleEffectExplosion(RaycastHit hitInfo)
    {

        //var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);

        var hitEffect = Instantiate(_hitParticles, hitInfo.point, Quaternion.identity);

        Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
    }

    public void SpawnParticleEffectMiss(RaycastHit hitInfo)
    {
        var missEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var missEffect = Instantiate(_missParticles, hitInfo.point, missEffectRotation);

        Destroy(missEffect.gameObject, _hitEffectDestroyDelay);
    }
}
