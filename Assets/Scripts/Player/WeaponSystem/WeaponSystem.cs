using UnityEngine;
using System.Collections.Generic;

public class WeaponSystem : MonoBehaviour
{
    public List<Weapon> unlockedWeapons = new List<Weapon>();  // Список доступных оружий
    private Weapon currentWeapon;                              // Текущее оружие
    private int currentWeaponIndex = 0;                        // Индекс текущего оружия

    void Start()
    {

        // Допустим, начнем с первого доступного оружия
        if (unlockedWeapons.Count > 0)
        {
            EquipWeapon(0);
        }
    }

    void Update()
    {
        // Проверка нажатия левой кнопки мыши для стрельбы
        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.Attack();
        }

        // Переключение оружия
        if (Input.GetKeyDown(KeyCode.Q))  // Вверх по списку
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))  // Вниз по списку
        {
            SwitchWeapon(-1);
        }
    }

    // Метод для смены оружия
    void SwitchWeapon(int direction)
    {
        currentWeaponIndex += direction;

        // Циклическое переключение
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

    // Метод для экипировки оружия
    void EquipWeapon(int index)
    {
        if (unlockedWeapons.Count > 0 && index < unlockedWeapons.Count)
        {
            // Деактивируем предыдущее оружие
            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            // Активируем новое оружие
            currentWeapon = unlockedWeapons[index];
            currentWeapon.gameObject.SetActive(true);
        }
    }

    // Метод для разблокировки нового оружия
    public void UnlockWeapon(Weapon newWeapon)
    {
        unlockedWeapons.Add(newWeapon);
    }
}