using System;

[Serializable]
public class StepSpawnConfig 
{
    public int capsuleEnemyAmount;
    public int cubeEnemyAmount;
    public int cylinderEnemyAmount;   
    public int sphereEnemyAmount;
    public float spawnTime;

    public float GetAllAmountEnemy()
    {
        return capsuleEnemyAmount + cubeEnemyAmount + cylinderEnemyAmount + sphereEnemyAmount;
    }
}
