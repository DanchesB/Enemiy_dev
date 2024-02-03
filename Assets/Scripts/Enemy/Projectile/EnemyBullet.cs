using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public ProjectileEnemy enemy;

    [SerializeField] private float damageArea = 10f;
    private PlayerHealth playerHealth;
    private int damage;
    private Vector3 attackPos;

    [SerializeField] private AnimationCurve curve;
    public float bulletSpeed = 10f;
    public float ballHeigh = 10f;

    IEnumerator coroutine = null;

    public void Initialize(PlayerHealth playerHealth, int damage, Vector3 attackPos)
    {
        this.playerHealth = playerHealth;
        this.damage = damage;
        this.attackPos = attackPos;
    }

    private void Update()
    {
        Trajectory();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damage();
    }

    void Damage()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, damageArea);
        foreach (Collider collider in player)
        {
            if (collider.tag == "Player")
            {
                playerHealth.HealthReduce(damage);
            }
        }

        Destroy(gameObject);
    }

    private void Trajectory()
    {
        if (coroutine == null)
        {
            coroutine = FollowCurve();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator FollowCurve()
    {
        Vector3 pathVector = attackPos - transform.position;
        float totalDistance = pathVector.magnitude;
        pathVector.Normalize();

        float distanceTravelled = 0f;
        float ballradius = transform.localScale.y / 2f;

        Vector3 newPosition = transform.position;

        while (distanceTravelled <= totalDistance)
        {
            Vector3 deltaPath = pathVector * (bulletSpeed * Time.deltaTime);
            newPosition += deltaPath;
            distanceTravelled += deltaPath.magnitude;

            newPosition.y = ballradius + (ballHeigh * curve.Evaluate(distanceTravelled / totalDistance));

            transform.position = newPosition;

            yield return null;
        }

        coroutine = null;
    }
}
