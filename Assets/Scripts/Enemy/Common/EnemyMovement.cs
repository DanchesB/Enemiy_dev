using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public Transform target;
    [HideInInspector] public PlayerHealth PlayerHealth;
    private ICanAttack attack;
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] public float rotationSpeed;

    public void Initialize(Transform player, PlayerHealth playerHealth)
    {
        this.target = player;
        this.PlayerHealth = playerHealth;

        try
        {
            attack = GetComponent<ICanAttack>();
        }
        catch
        {
            return;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Movement();
        }
    }

    private void Movement()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        if (!PlayerIsClose())
        {
            transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
        }
        else
        {
            try
            {
                attack.AttackProcess();
            }
            catch
            {
                return;
            }
        }
    }

    private bool PlayerIsClose()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        return distance <= attackDistance;
    }
}
