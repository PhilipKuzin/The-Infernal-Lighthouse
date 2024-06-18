using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Lighthouse : MonoBehaviour, IDamagable, IEnemyTarget
{
    [SerializeField] private Rigidbody _rb;
    private MovementHandler _movementHandler;
    private float _moveSpeed = 10;
    public Vector3 Position => transform.position;

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += ClickAction;
    }

    private void ClickAction(Vector3 position)
    {
        Debug.Log("DebugClickFromLighthouse");
        Ray ray = Camera.main.ScreenPointToRay(position);
        if(Physics.Raycast(ray, out RaycastHit hit)) 
        {
            GameObject go = hit.transform.gameObject;

            if (go.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage();
        }
    }

    void LookOnCursor(Vector3 position)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(position);
        float hitdist = 0;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage()
    {
        throw new NotImplementedException();
    }
}
