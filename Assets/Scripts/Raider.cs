using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(RaiderInput))]

public class Raider : Character
{
    public static List<Raider> Collection;

    protected void OnEnable()
    {
        base.OnEnable();
        if (Collection == null)
            Collection = new List<Raider>();
        Collection.Add(this);
    }

    protected void OnDisable()
    {
        Collection.Remove(this);
    }

    public override void GoTo(Vector3 destination)
    {
        agent.SetDestination(destination);
        agent.stoppingDistance = 0;
        IsEngaged = false;
        print("going to: " + destination);
    }

    public override void Assist(Character character)
    {
        print("Assisting: " + character.MyInfo.Name);
    }

    public override void Engage(Enemy enemy)
    {
        MyEnemy = enemy;
        agent.SetDestination(MyEnemy.Position);
        agent.stoppingDistance = MyAttack.Range + HitBoxRadius + MyEnemy.HitBoxRadius;
        agent.autoBraking = true;
        IsEngaged = true;
        print(MyInfo.Name + " Engaging: " + MyEnemy.EnemyName + " Stop: " + CombatHelper.GetCombatDistance(this, MyEnemy));
    }

    public override void UsePrimarySkill()
    {
        print(MyInfo.Name + "used: " + PrimarySkill.Name + "(PS)");
    }

    public override void UseSecondarySkill()
    {
        print(MyInfo.Name + "used: " + SecondarySkill.Name + "(SS)");
    }

}