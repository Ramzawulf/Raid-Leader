using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Character : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent agent;
	public string CharacterName;
	public Sprite Portrait;
	public float speed = 5;
	public Skill PrimarySkill;
	public Skill SecondarySkill;
	public float MaxHealth = 100;
	public float CurrentHealth = 100;
    public float AttackRange;
    public float HitBoxRadius = 0.5f;

    void Start ()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.speed = speed;
		GameController.Handle.AddCharacter (this);
	}

	public void GoTo (Vector3 destination)
	{
		agent.SetDestination (destination);
		print ("going to: " + destination);
	}

	public void UsePrimarySkill ()
	{
		print (CharacterName + "used: " + PrimarySkill.Name + "(PS)");
	}

	public void UseSecondarySkill ()
	{
		print (CharacterName + "used: " + SecondarySkill.Name + "(SS)");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    public void Engage(Enemy enemy)
    {
        agent.SetDestination(enemy.Position);
        agent.stoppingDistance = CombatHelper.GetCombatDistance(this, enemy);
        agent.autoBraking = true;
        print("Engaging: " + enemy.Name + " Stop: " + CombatHelper.GetCombatDistance(this, enemy));
    }
}
