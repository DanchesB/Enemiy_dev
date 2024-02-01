using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    private PlayerHealth PlayerHealth;
    private Vector3 Target;
    private Quaternion TargetRotation;

    public float speed = 5f;
    public int Damage = 5;
    public float timer = 5f;

    public void Initialize(PlayerHealth playerHealth, Vector3 Target, int damage)
    {
        this.PlayerHealth = playerHealth;
        this.Damage = damage;
        this.Target = Target;
    }

    private void Start()
    {
        transform.LookAt(Target);
    }

    void Update()
    {
        // Move towards the target
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Destroy();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if reached the target
        if (other.CompareTag("Player"))
        {
            // Damage the player
            DamagePlayer();

            // Destroy the spit object
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    void DamagePlayer()
    {
        // Implement logic to damage the player
        
        if (PlayerHealth != null)
        {
            PlayerHealth.HealthReduce(Damage);
        }
    }
}
