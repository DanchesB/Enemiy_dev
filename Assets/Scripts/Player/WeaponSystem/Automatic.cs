using UnityEngine;

public class Automatic : Weapon
{
    public Transform firePoint;

    public override void Attack()
    {
        FireBullet(firePoint); // Используем метод стрельбы с другой скорострельностью
    }
}
