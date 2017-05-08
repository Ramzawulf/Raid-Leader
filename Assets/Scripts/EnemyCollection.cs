using System.Collections.Generic;
using UnityEngine;

public class EnemyCollection: MonoBehaviour
{
    private List<Enemy> enemies;

    void Awake()
    {
        enemies = new List<Enemy>();

    }
    
    public void AddEnemy(Enemy newEnemy) {
        if (!enemies.Contains(newEnemy))
        {
            enemies.Add(newEnemy);
            newEnemy.transform.SetParent(transform);
        }
    }

}