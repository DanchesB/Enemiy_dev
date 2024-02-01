using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector] private PlayerHealth PlayerHealth;

    [SerializeField] private GameObject _settings;
    [SerializeField] private Explosion _explosion;

    public float timeToDelete = 2f;

    private int damage;
    private float radius;

    public void Initialize(PlayerHealth playerHealth, int damage, float radiusExplosion)
    {
        this.PlayerHealth = playerHealth;
        this.damage = damage;
        this.radius = radiusExplosion;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Damage();
        _explosion.CreateExplosionSphere(gameObject.transform);
        gameObject.SetActive(false);
        Invoke("Delete", timeToDelete);
    }

    private void Damage()
    {
        Collider[] playerCollider = Physics.OverlapSphere(this.gameObject.transform.position, radius);
        foreach (Collider collider in playerCollider)
        {
            if (collider.tag == "Player")
            {
                PlayerHealth.HealthReduce(damage);
            }
        }
    }

    private void Delete()
    {
        _explosion.DeleteSphere();
        Destroy(this.gameObject);
    }
}
