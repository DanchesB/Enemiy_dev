using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitEnemy : MonoBehaviour, ICanAttack
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject SpitPrefab;
    private bool isAttack = false;
    private float timer = 0;

    //  variable for spitting range and disable distance
    [SerializeField] private float attackDelay = 2f;
    [SerializeField] private int damage = 2;

    private void Start()
    {
        playerHealth = GetComponent<EnemyMovement>().PlayerHealth;
        target = GetComponent<EnemyMovement>().target;
    }

    private void SpittingAttack()
    {
        // Replace "SpitPrefab" with the actual prefab you want to instantiate
        GameObject spitObject = Instantiate(SpitPrefab, transform.position, Quaternion.identity);
        Spit spitComponent = spitObject.GetComponent<Spit>();

        spitComponent.Initialize(playerHealth, target.position, damage);
        isAttack = false;
    }

    public void AttackProcess()
    {
        timer -= Time.deltaTime;
        if (timer < 0f && isAttack == false)
        {
            isAttack = true;
            SpittingAttack();
            timer = attackDelay;
        }
    }
}
