using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnManager : MonoBehaviour
{
    public Transform target;
    public PlayerHealth playerHealth = new PlayerHealth();

    [Header("EnemySettings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private StepSpawnConfig[] stepSpawnConfigs;

    private Dictionary<string, EnemyPool<Transform>> enemyPools;
    private int currentStep = 0;
    public int startPoolSize = 10;

    private void Start()
    {
        enemyPools = new Dictionary<string, EnemyPool<Transform>>();
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            GameObject enemyContainer = new GameObject(enemyPrefabs[i].tag + "_Container");         
            enemyPools.Add(enemyPrefabs[i].tag, new EnemyPool<Transform>(enemyPrefabs[i].GetComponent<Transform>(),
                                                                      startPoolSize,
                                                                      enemyContainer.transform));
        }

        StartNextSpawnStep();
    }

    private void StartNextSpawnStep()
    {
        if (currentStep < stepSpawnConfigs.Length)
        {        
            StartCoroutine(SpawnEnemiesOnStep(stepSpawnConfigs[currentStep]));
            Debug.Log("ступень спавна " + currentStep);
            currentStep++;
            StartNextSpawnStep();
        }
        else      
            Debug.Log("Ступени спавна кончились");
    }

    private IEnumerator SpawnEnemiesOnStep(StepSpawnConfig stepConfig)
    {
        float totalEnemiesToSpawn = stepConfig.GetAllAmountEnemy();
        List<string> enemyTypes = new List<string>();
      
        for (int i = 0; i < stepConfig.capsuleEnemyAmount; i++)
            enemyTypes.Add("Capsule");
        for (int i = 0; i < stepConfig.cubeEnemyAmount; i++)
            enemyTypes.Add("Cube");
        for (int i = 0; i < stepConfig.cylinderEnemyAmount; i++)
            enemyTypes.Add("Cylinder");
        for (int i = 0; i < stepConfig.sphereEnemyAmount; i++)
            enemyTypes.Add("Sphere");
      
        enemyTypes.Shuffle();

        float spawnDelay = stepConfig.spawnTime / totalEnemiesToSpawn;

        foreach (string enemyType in enemyTypes)
        {          
            if (enemyPools.TryGetValue(enemyType, out EnemyPool<Transform> pool))
            {
                SpawnEnemyFromPool(pool);
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                Debug.LogWarning("неверный тип врагов: " + enemyType);
            }
        }
    }

    private void SpawnEnemyFromPool(EnemyPool<Transform> pool)
    {    
        Transform randomSpawnPoint = GetRandomSpawnPoint();      
        Transform enemy = pool.GetObject();
        enemy.position = randomSpawnPoint.position;
        enemy.GetComponent<EnemyMovement>().Initialize(target, playerHealth);
    }  
    private Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}