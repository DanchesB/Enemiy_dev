using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth;

    private bool isDead;

    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Death();
        }
        else
        {
            // do something
        }
    }

    private void Death()
    {
        Debug.Log("Hitted object dead");
        isDead = true;
    }

    private void DrawCurrentHealth()
    {

    }
}