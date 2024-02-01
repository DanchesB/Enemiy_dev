using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.GraphicsBuffer;

public class MelleEnemy : MonoBehaviour, ICanAttack
{
    private PlayerHealth playerHealth;
    private Transform target;

    [SerializeField] private float attackDelay;
    [SerializeField] private int damage;

    private float timer = 0;
    private bool isAttack = false;

    private void Start()
    {
        playerHealth = GetComponent<EnemyMovement>().PlayerHealth;
        target = GetComponent<EnemyMovement>().target;
    }

    private void StartAttack()
    {
        MelleAttack();
        isAttack = false;
    }

    private void MelleAttack()
    {
        playerHealth.HealthReduce(damage);
    }

    public void AttackProcess()
    {
        timer -= Time.deltaTime;
        if (timer < 0f && isAttack == false)
        {
            isAttack = true;
            StartAttack();
            timer = attackDelay;
        }
    }
}
