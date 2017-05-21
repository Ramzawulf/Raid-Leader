using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameConfiguration
{
    public CharacterConfiguration[] Characters;
    public EnemyConfiguration[] Enemies;
    private static string CONFIG_KEY = "CONFIGURATION_KEY";
}

[System.Serializable]

public class EnemyConfiguration
{
    public string EnemyName;
    public float HitBoxRadius;

    public GameObject Create()
    {
        GameObject go = GameObject.Instantiate(PrefabManager.Instance.EnemyPrefab);
        Enemy e = go.AddComponent<Enemy>();
        e.name = e.EnemyName = EnemyName;
        e.HitBoxRadius = HitBoxRadius;
        return go;

    }

}

    [System.Serializable]
public class CharacterConfiguration
{
    public string CharacterName;
    public Sprite Portrait;
    public float speed;
    public Skill PrimarySkill;
    public Skill SecondarySkill;
    public float MaxHealth;
    public float AttackRange;
    public float HitBoxRadius;

    public GameObject Create() {
        GameObject go = GameObject.Instantiate(PrefabManager.Instance.CharacterPrefab);
        Character c = go.AddComponent<Character>();
        c.name = c.CharacterName = CharacterName;
        c.Portrait = Portrait;
        c.speed = speed;
        c.PrimarySkill = PrimarySkill;
        c.SecondarySkill = SecondarySkill;
        c.MaxHealth = MaxHealth;
        c.AttackRange = AttackRange;
        c.HitBoxRadius = HitBoxRadius;
        return go;
    }
}