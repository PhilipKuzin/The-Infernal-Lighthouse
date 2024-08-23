using System;
using System.Threading.Tasks;
using UnityEngine;

public class RaycastAttak
{
    public event Action<RaycastHit> OnEnemyKilled;
    public event Action<RaycastHit> OnMiss;

    private int shotCount = 0; // Счетчик выстрелов
    private bool isReloading = false; // Флаг перезарядки

    public async void PerformAttack(Vector3 position) // Изменяем метод на async
    {
        if (isReloading)
        {
            Debug.Log("Перезарядка... Подождите.");
            return; // Если идет перезарядка, выходим из метода
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

        // Проверяем, нужно ли начинать перезарядку
        if (shotCount >= 5)
        {
            await Reload(); // Ждем завершения перезарядки
            shotCount = 0; // Сбрасываем счетчик выстрелов после перезарядки
        }
    }

    private async Task Reload() // Метод для перезарядки
    {
        isReloading = true; // Устанавливаем флаг перезарядки
        Debug.Log("Начинаем перезарядку...");

        await Task.Delay(3000); // Ждем 3 секунды

        Debug.Log("Перезарядка завершена.");
        isReloading = false; // Сбрасываем флаг перезарядки
    }
}