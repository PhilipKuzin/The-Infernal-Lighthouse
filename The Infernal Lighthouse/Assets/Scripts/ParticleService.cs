using UnityEngine;

public class ParticleService : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private ParticleSystem _missParticles;
    [SerializeField] private ParticleSystem _playerExplosionParticles;

    private float _hitEffectDestroyDelay = 2;

    public void SpawnParticleEffectExplosion(RaycastHit hitInfo)
    {
        var hitEffect = Instantiate(_hitParticles, hitInfo.point, Quaternion.identity);

        Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
    }

    public void SpawnParticleEffectMiss(RaycastHit hitInfo)
    {
        var missEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var missEffect = Instantiate(_missParticles, hitInfo.point, missEffectRotation);

        Destroy(missEffect.gameObject, _hitEffectDestroyDelay);
    }

    public void SpawnParticleEffectPlayerExplosion(Vector3 position)
    {
        var playerExplosionEffect = Instantiate(_playerExplosionParticles, position, Quaternion.identity);

        Destroy(playerExplosionEffect.gameObject, _hitEffectDestroyDelay);
    }
}
