using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private GameObject explosion;
    private GameObject explosionDamage;


    public void CreateSphere(Vector3 _attackPos, float _radius, GameObject explosionPrefab)
    {
        if (explosion == null)
        {
            explosion = Instantiate(explosionPrefab, _attackPos, Quaternion.identity) as GameObject;
            explosion.transform.localScale = new Vector3(_radius, 0.1f, _radius);
        }
    }

    public void CreateDamageSphere(Vector3 _attackPos, float _radius, GameObject explosionPrefab)
    {
        if (explosionDamage == null)
        {
            explosionDamage = Instantiate(explosionPrefab, _attackPos, Quaternion.identity) as GameObject;
            explosionDamage.transform.localScale = new Vector3(_radius, 0.2f, _radius);
        }
    }

    public void DeleteDamageSphere()
    {
        if (explosionDamage != null)
        {
            Destroy(explosionDamage);
        }
    }

    public void DeleteSphere()
    {
        if (explosion != null)
        {
            Destroy(explosion);
        }
    }
}
