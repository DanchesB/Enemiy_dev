using System;

[Serializable]
public class StepSpawnConfig 
{
    public int meleeEnemyAmount;
    public int ramEnemyAmount;
    public int spitEnemyAmount;   
    public int projectileEnemyAmount;
    public float spawnTime;

    public float GetAllAmountEnemy()
    {
        return meleeEnemyAmount + ramEnemyAmount + spitEnemyAmount + projectileEnemyAmount;
    }
}
