using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, ICanAttack
{
    [SerializeField] private GameObject _enemyBullet;
    //[SerializeField] private TrajectoryRenderer _trajectoryRendere;
    //[SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Explosion _explosion;

    private PlayerHealth playerHealth;
    public Transform _firePoint;
    private Transform _playerPosition;
    public float angle;
    public float g = Physics.gravity.y;
    public float timeNextTime = 1f;
    public float radiusExplosion = 10f;
    public int damage;

    private float _attackDistance;
    private float timeToShoot = 0f;
    private Vector3 currentPosition;

    private EnemyMovement enemyMovement;

    //private int lineCount = 0;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        _playerPosition = enemyMovement.target.transform;
        playerHealth = enemyMovement.PlayerHealth;
    }

    public void AttackProcess()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _firePoint.localEulerAngles = new Vector3(-angle, 0f, 0f);

        Vector3 fromTo = _playerPosition.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
        float x = fromToXZ.magnitude;
        float y = fromTo.y;
        float angleInRagian = angle * Mathf.PI / 180;

        float V2 = (g * (x * x)) / (2 * (y - Mathf.Tan(angleInRagian) * x) * Mathf.Pow(Mathf.Cos(angleInRagian), 2));
        float V = Mathf.Sqrt(Mathf.Abs(V2));
        Vector3 speed = _firePoint.forward * V;
        _explosion.CreateSphere(_playerPosition);
        currentPosition = _playerPosition.position;
        Shoot(speed);
        Invoke("DeleteExlousinSphere", timeNextTime - 0.5f);

        yield return new WaitForSeconds(timeNextTime * Time.deltaTime);
    }

    private void Shoot(Vector3 speed)
    {
        GameObject newBullet = Instantiate(_enemyBullet, _firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(speed, ForceMode.VelocityChange);
        newBullet.GetComponent<BulletScript>().Initialize(playerHealth, damage, radiusExplosion);
    }

    private void DeleteExlousinSphere()
    {
        _explosion.DeleteSphere();
    }
}
