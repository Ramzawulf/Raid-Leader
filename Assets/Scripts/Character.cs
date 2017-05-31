using UnityEngine;
using UnityEngine.AI;
using System.Text;
using UnityEngine.UI;
using System.Collections;
using System;
using Assets.Scripts;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    public RaiderInfo MyInfo;
    protected NavMeshAgent agent;
    public float speed = 5;
    public Skill PrimarySkill;
    public Skill SecondarySkill;
    public float MaxHealth = 100;
    public float CurrentHealth = 100;
    public AttackBehaviour MyAttack;
    public float HitBoxRadius = 0.5f;
    protected Animator anim;
    public Enemy MyEnemy;
    protected bool IsEngaged = false;

    public static List<Character> Collection;

    protected void OnEnable()
    {
        if (Collection == null)
            Collection = new List<Character>();
        Collection.Add(this);
    }

    protected void OnDisable()
    {
        Collection.Remove(this);
    }

    protected void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = speed;
        MyInfo = new RaiderInfo();
        //MyAttack = new AttackBehaviour();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(MyInfo.Name + " H: " + MaxHealth + "/" + CurrentHealth);
        sb.AppendLine("-Enemy: " + MyEnemy + "Eng: " + IsEngaged + " Rng: " + InRange());
        sb.AppendLine("-Dist: " + agent.remainingDistance);
        return sb.ToString();
    }

    #region Combat
    protected bool InRange()
    {
        if (MyEnemy == null)
            return false;
        float combatDistance = MyAttack.Range + HitBoxRadius + MyEnemy.HitBoxRadius;
        if (agent.remainingDistance <= combatDistance)
            return true;
        return false;
    }
    #endregion

    #region Actions
    public virtual void GoTo(Vector3 destination)
    {
    }

    public virtual void UsePrimarySkill()
    {
    }

    public virtual void UseSecondarySkill()
    {
    }

    public virtual void Engage(Enemy enemy)
    {
    }

    public virtual void Assist(Character character)
    {
    }
    #endregion

    #region Pause

    public void Pause() {
        agent.speed = 0;
        MyAttack.Pause();
    }
    public void UnPause() {
        agent.speed = speed;
        MyAttack.UnPause();
    }

    #endregion
}
