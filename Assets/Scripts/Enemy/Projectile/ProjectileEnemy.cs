using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileEnemy : MonoBehaviour, ICanAttack
{
    public Transform _explosion;
    public GameObject _bulletPrefab;
    public int _damage;
    public float _attackDelay;
    public float _damageArea;
    public Transform _firePoint;
    public float angle;
    private PlayerHealth health;

    private Transform target;
    private Vector3 attackPos;   
    private GameObject bullet;
    public EnemyMovement enemyMovement;
    private bool isAttack = false;
    private float timer = 0;
    private float g = 9.8f;

    private void Start()
    {
        health = enemyMovement.PlayerHealth;
        target = enemyMovement.target;
        if (health != null )
        {
            Debug.Log("Asfdasfasdfasd");
        }
    }

    void StartAttack()
    {
        attackPos = new Vector3(target.position.x, 0.1f, target.position.z);
        Instantiate(_explosion, attackPos, Quaternion.identity);
        isAttack = false;
    }

    void Trajectory()
    {
        _firePoint.localEulerAngles = new Vector3(-angle, 0f, 0f);

        Vector3 fromTo = attackPos - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
        float x = fromToXZ.magnitude;
        float y = fromTo.y;
        float angleInRagian = angle * Mathf.PI / 180;

        float V2 = (g * (x * x)) / (2 * (y - Mathf.Tan(angleInRagian) * x) * Mathf.Pow(Mathf.Cos(angleInRagian), 2));
        float V = Mathf.Sqrt(Mathf.Abs(V2));
        Vector3 speed = _firePoint.forward * (V - 1);
        //_explosion.CreateSphere(_playerPosition);
        //currentPosition = _playerPosition.position;

        GameObject newBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(speed, ForceMode.VelocityChange);
        newBullet.GetComponent<EnemyBullet>().Initialize(health, _damage);
    }

    public void HealthAttack(int damage)
    {
        enemyMovement.PlayerHealth.HealthReduce(damage);
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
