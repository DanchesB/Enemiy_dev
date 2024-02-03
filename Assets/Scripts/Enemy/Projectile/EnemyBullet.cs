using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public ProjectileEnemy enemy;

    private float damageArea;
    private PlayerHealth PlayerHealth;
    private int damage = 100;

    public void Initialize(PlayerHealth playerHealth, int damage)
    {
        this.PlayerHealth = playerHealth;
        this.damage = damage;
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
                PlayerHealth.HealthReduce(damage);
            }
        }
    }
}
