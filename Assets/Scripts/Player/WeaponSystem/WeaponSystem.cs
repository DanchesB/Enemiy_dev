using UnityEngine;
using System.Collections.Generic;

public class WeaponSystem : MonoBehaviour
{
    public List<Weapon> unlockedWeapons = new List<Weapon>();  // ������ ��������� ������
    private Weapon currentWeapon;                              // ������� ������
    private int currentWeaponIndex = 0;                        // ������ �������� ������

    void Start()
    {

        // ��������, ������ � ������� ���������� ������
        if (unlockedWeapons.Count > 0)
        {
            EquipWeapon(0);
        }
    }

    void Update()
    {
        // �������� ������� ����� ������ ���� ��� ��������
        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.Attack();
        }

        // ������������ ������
        if (Input.GetKeyDown(KeyCode.Q))  // ����� �� ������
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))  // ���� �� ������
        {
            SwitchWeapon(-1);
        }
    }

    // ����� ��� ����� ������
    void SwitchWeapon(int direction)
    {
        currentWeaponIndex += direction;

        // ����������� ������������
        if (currentWeaponIndex >= unlockedWeapons.Count)
        {
            currentWeaponIndex = 0;
        }
        else if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = unlockedWeapons.Count - 1;
        }

        EquipWeapon(currentWeaponIndex);
    }

    // ����� ��� ���������� ������
    void EquipWeapon(int index)
    {
        if (unlockedWeapons.Count > 0 && index < unlockedWeapons.Count)
        {
            // ������������ ���������� ������
            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            // ���������� ����� ������
            currentWeapon = unlockedWeapons[index];
            currentWeapon.gameObject.SetActive(true);
        }
    }

    // ����� ��� ������������� ������ ������
    public void UnlockWeapon(Weapon newWeapon)
    {
        unlockedWeapons.Add(newWeapon);
    }
}