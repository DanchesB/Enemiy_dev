using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public ProjectileEnemy enemy;
    public Explosion exp;
    public GameObject explosionPrefab;
    public GameObject explosionDamagePrefab;
    public float timeToDelete = 2f;

    [SerializeField] private float damageArea = 10f;
    private PlayerHealth playerHealth;
    private int damage;
    private Vector3 attackPos;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float desiredFlightTime = 2f;
    private float bulletSpeed;
    public float ballHeigh = 10f;

    IEnumerator coroutine = null;

    public void Initialize(PlayerHealth playerHealth, int damage, Vector3 attackPos)
    {
        this.playerHealth = playerHealth;
        this.damage = damage;
        this.attackPos = attackPos;
        exp.CreateSphere(attackPos, damageArea, explosionPrefab);

        // –ассчитываем скорость снар€да на основе желаемого времени полЄта и рассто€ни€ до цели
        bulletSpeed = Vector3.Distance(transform.position, attackPos) / desiredFlightTime;

    }

    private void Update()
    {
        Trajectory();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damage();
        exp.DeleteSphere();
        this.gameObject.SetActive(false);
        exp.CreateDamageSphere(attackPos, damageArea, explosionDamagePrefab);
        Invoke("DeleteBullet", timeToDelete);
    }

    void DeleteBullet()
    {
        exp.DeleteDamageSphere();
        Destroy(this.gameObject);
    }

    void Damage()
    {
        Collider[] player = Physics.OverlapSphere(attackPos, damageArea / 2);
        foreach (Collider collider in player)
        {
            if (collider.tag == "Player")
            {
                playerHealth.HealthReduce(damage);
            }
        }
    }

    private void Trajectory()
    {
        if (coroutine == null)
        {
            coroutine = FollowCurve();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator FollowCurve()
    {
        Vector3 pathVector = attackPos - transform.position;
        float totalDistance = pathVector.magnitude;
        Vector3 normalizedDirection = pathVector.normalized; // Ќормализованный вектор направлени€

        float distanceTravelled = 0f;
        float ballRadius = transform.localScale.y / 2f;

        Vector3 newPosition = transform.position;

        while (distanceTravelled <= totalDistance)
        {
            Vector3 deltaPath = normalizedDirection * (bulletSpeed * Time.deltaTime);
            newPosition += deltaPath;
            distanceTravelled += deltaPath.magnitude;

            float normalizedTime = distanceTravelled / totalDistance;
            newPosition.y = ballRadius + (ballHeigh * curve.Evaluate(normalizedTime));

            transform.position = newPosition;

            yield return null;
        }

        coroutine = null;
    }
}

