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
    private EnemyMovement enemyMovement;

    [SerializeField] private float attackDelay;
    [SerializeField] private int damage;

    private float timer = 0;
    private bool isAttack = false;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        playerHealth = enemyMovement.PlayerHealth;
        target = enemyMovement.target;
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
