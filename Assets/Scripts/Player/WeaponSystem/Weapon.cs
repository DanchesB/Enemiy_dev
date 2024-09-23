using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;      // �������� ������
    public GameObject bulletPrefab; // ������ ����
    public float fireRate;          // ����������������

    private float nextFireTime;     // ����� �� ���������� ��������

    // ����� ��������, ������� ������ ���� ���������� � ������ ���������� ������
    public abstract void Attack();

    // ��������������� �����, ������� ���������, ����� �� ��������
    protected bool CanAttack()
    {
        return Time.time >= nextFireTime;
    }

    // �����, ������� �������� �������� � ����� ����� ���������� ��������
    protected void FireBullet(Transform firePoint)
    {
        if (CanAttack())
        {
            // �������� ���� � � ��������
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * 20f;  // ����� �������� ����

            nextFireTime = Time.time + 1f / fireRate; // ������������ ����� �� ���������� ��������
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
