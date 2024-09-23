using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;      // Название оружия
    public GameObject bulletPrefab; // Префаб пули
    public float fireRate;          // Скорострельность

    private float nextFireTime;     // Время до следующего выстрела

    // Метод стрельбы, который должен быть реализован в каждом конкретном оружии
    public abstract void Attack();

    // Вспомогательный метод, который проверяет, можно ли стрелять
    protected bool CanAttack()
    {
        return Time.time >= nextFireTime;
    }

    // Метод, который вызывает стрельбу и задаёт время следующего выстрела
    protected void FireBullet(Transform firePoint)
    {
        if (CanAttack())
        {
            // Создание пули и её движение
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * 20f;  // Задаём скорость пули

            nextFireTime = Time.time + 1f / fireRate; // Рассчитываем время до следующего выстрела
        }
    }

    protected void MeleeAttack()
    {
        if (CanAttack())
        {
            Debug.Log("BAM!");
        }
    }
}
