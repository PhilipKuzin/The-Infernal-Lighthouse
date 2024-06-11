using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Lighthouse : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    private MovementHandler _movementHandler;

    private float moveSpeed = 10;

    [Inject]
    private void Construct(MovementHandler movementHandler)
    {
        _movementHandler = movementHandler;
        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += DebugClickFromLighthouse; ;
    }

    private void DebugClickFromLighthouse(Vector3 vector)
    {
        Debug.Log("DebugClickFromLighthouse");
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
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
        }
    }


}
