using System;

[Serializable]
public class StepSpawnConfig 
{
    public int melee1EnemyAmount;
    public int ram1EnemyAmount;
    public int spit1EnemyAmount;   
    public int projectile1EnemyAmount;
    public float spawnTime;

    public float GetAllAmountEnemy()
    {
        return melee1EnemyAmount + ram1EnemyAmount + spit1EnemyAmount + projectile1EnemyAmount;
    }
}
