using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    public override void Attack()
    {
        MeleeAttack(); // Используем метод стрельбы из базового класса
    }
}
