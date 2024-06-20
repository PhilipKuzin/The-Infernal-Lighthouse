using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Lighthouse : MonoBehaviour, IDamageable, IEnemyTarget
{
    private RaycastAttak _raycastAttack;
    private MovementHandler _movementHandler;
    private float _moveSpeed = 10;
    public Vector3 Position => transform.position;

    [Inject]
    private void Construct(MovementHandler movementHandler, RaycastAttak raycastAttak)
    {
        _movementHandler = movementHandler;
        _raycastAttack = raycastAttak;
        _movementHandler.OnMove += LookOnCursor;
        _movementHandler.OnClicked += ClickAction;
    }

    public void TakeDamage()
    {
        Debug.Log("DAMAGE APPLIED BY LIGHTHOUSE");
    }

    private void ClickAction(Vector3 position)
    {
        _raycastAttack.PerformAttack(position);
    }

    private void LookOnCursor(Vector3 position)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (playerPlane.Raycast(ray, out float hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _moveSpeed * Time.deltaTime);
        }
    }


}
