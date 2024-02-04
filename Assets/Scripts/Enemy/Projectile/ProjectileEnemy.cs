using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileEnemy : MonoBehaviour, ICanAttack
{
    public GameObject _bulletPrefab;
    public int _damage;
    public float _attackDelay;
    public Transform _firePoint;

    private PlayerHealth health;
    private Transform target;
    private Vector3 attackPos;
    private EnemyMovement enemyMovement;
    private bool isAttack = false;
    private float timer = 0;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        health = enemyMovement.PlayerHealth;
        target = enemyMovement.target;
    }

    void StartAttack()
    {
        attackPos = new Vector3(target.position.x, 0.1f, target.position.z);
        isAttack = false;
    }

    void Trajectory()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        newBullet.GetComponent<EnemyBullet>().Initialize(health, _damage, attackPos);
    }

    public void AttackProcess()
    {
        timer -= Time.deltaTime;
        if (timer < 0f && isAttack == false)
        {
            isAttack = true;
            StartAttack();
            Trajectory();
            timer = _attackDelay;
        }
    }
}
