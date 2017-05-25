using Assets.Scripts;
using UnityEngine;
[System.Serializable]

public class EnemyConfiguration
{
    public string EnemyName;
    public float HitBoxRadius;
    public float Health;
    public AttackBehaviour Attack;

    public GameObject Create()
    {
        GameObject go = GameObject.Instantiate(PrefabManager.Instance.EnemyPrefab);
        Enemy e = go.AddComponent<Enemy>();
        e.name = e.EnemyName = EnemyName;
        e.HitBoxRadius = HitBoxRadius;
        e.Attack = Attack;
        e.MaxHealth = Health;
        e.CurrentHealth = Health;
        return go;
    }

}
