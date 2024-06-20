using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttak : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticleSystem;

    private float _hitEffectDestroyDelay = 2;

    public void PerformAttack(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable enemy))
            {
                SpawnParticleEffectOnHit(hitInfo);
                enemy.TakeDamage();
            }
            else
            {
                // если компонент IDamagable не найден (например партиклы промаха) 
            }
        }
    }

    private void SpawnParticleEffectOnHit(RaycastHit hitInfo)
    {
        Debug.Log("Отработал SpawnEffectOnHit");


        var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
        var hitEffect = Instantiate(_hitParticleSystem, hitInfo.point, hitEffectRotation);

        Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
    }

}
