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

    public void Initialize(PlayerHealth playerHealth, int damage, Vector3 attackPos)
    {
        this.playerHealth = playerHealth;
        this.damage = damage;
        this.attackPos = attackPos;
        Debug.Log(attackPos);
    }

    /*private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, attackPos, 10f * Time.deltaTime);
    }*/

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
                Debug.Log(transform.position);
                playerHealth.HealthReduce(damage);

            }
        }

        Destroy(gameObject);
    }
}
