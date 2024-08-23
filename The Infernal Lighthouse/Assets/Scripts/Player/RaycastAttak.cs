using System;
using System.Threading.Tasks;
using UnityEngine;

public class RaycastAttak
{
    public event Action<RaycastHit> OnEnemyKilled;
    public event Action<RaycastHit> OnMiss;

    private int shotCount = 0; // ������� ���������
    private bool isReloading = false; // ���� �����������

    public async void PerformAttack(Vector3 position) // �������� ����� �� async
    {
        if (isReloading)
        {
            Debug.Log("�����������... ���������.");
            return; // ���� ���� �����������, ������� �� ������
        }

        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable entity) && entity is Enemy realEnemy)
            {
                OnEnemyKilled?.Invoke(hitInfo);
                realEnemy.TakeDamage();
            }
            else
            {
                OnMiss?.Invoke(hitInfo);
            }
        }

        shotCount++;

        // ���������, ����� �� �������� �����������
        if (shotCount >= 5)
        {
            await Reload(); // ���� ���������� �����������
            shotCount = 0; // ���������� ������� ��������� ����� �����������
        }
    }

    private async Task Reload() // ����� ��� �����������
    {
        isReloading = true; // ������������� ���� �����������
        Debug.Log("�������� �����������...");

        await Task.Delay(3000); // ���� 3 �������

        Debug.Log("����������� ���������.");
        isReloading = false; // ���������� ���� �����������
    }
}