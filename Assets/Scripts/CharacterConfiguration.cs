using Assets.Scripts;
using UnityEngine;
[System.Serializable]
public class CharacterConfiguration
{
    public string CharacterName;
    public Sprite Portrait;
    public float speed;
    public Skill PrimarySkill;
    public Skill SecondarySkill;
    public float MaxHealth;
    public AttackBehaviour Attack;
    public float HitBoxRadius;

    public GameObject Create()
    {
        GameObject go = GameObject.Instantiate(PrefabManager.Instance.CharacterPrefab);
        Character c = go.AddComponent<Character>();
        c.name = c.CharacterName = CharacterName;
        c.Portrait = Portrait;
        c.speed = speed;
        c.PrimarySkill = PrimarySkill;
        c.SecondarySkill = SecondarySkill;
        c.MaxHealth = MaxHealth;
        c.MyAttack = Attack;
        c.HitBoxRadius = HitBoxRadius;
        return go;
    }
}