using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private EnemyProjectile enemyProjectile;
    private GameObject explosionPrefab;  
    private float radius;

    private void Start()
    {
        radius = enemyProjectile.radiusExplosion;
    }

    public void CreateSphere(Transform _playerTransform)
    {
        if (explosionPrefab == null) {
            Vector3 player = new Vector3(_playerTransform.position.x, 0.5f, _playerTransform.position.z);
            explosionPrefab = Instantiate(_explosion, player, Quaternion.identity) as GameObject;
            explosionPrefab.transform.localScale = new Vector3(radius, 0.1f, radius);
        } 
    }

    public void CreateExplosionSphere(Transform _playerTransform)
    {
        if (explosionPrefab == null)
        {
            Vector3 player = new Vector3(_playerTransform.position.x, 0.5f, _playerTransform.position.z);
            explosionPrefab = Instantiate(_explosion, player, Quaternion.identity) as GameObject;
            explosionPrefab.transform.localScale = new Vector3(radius, 0.2f, radius);
        }
    }

    public void DeleteSphere()
    {
        if (explosionPrefab != null)
        {
            Destroy(explosionPrefab);
        }
    }
}
