using UnityEngine;
using UnityEngine.AI;
using System.Text;
using UnityEngine.UI;
using System.Collections;
using System;
using Assets.Scripts;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private LineRenderer lRenderer;
    private NavMeshAgent agent;
    public string CharacterName;
    public Sprite Portrait;
    public float speed = 5;
    public Skill PrimarySkill;
    public Skill SecondarySkill;
    public float MaxHealth = 100;
    public float CurrentHealth = 100;
    public float AttackRange;
    public float HitBoxRadius = 0.5f;
    private bool isDragging;
    private Animator anim;
    public Enemy MyEnemy;
    private bool IsEngaged = false;

    private void Awake()
    {
        lRenderer = GetComponent<LineRenderer>() ?? gameObject.AddComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = speed;
    }

    void Start()
    {
        GameController.Handle.AddCharacter(this);
    }

    private void Update()
    {
        if (isDragging)
        {
            lRenderer.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                lRenderer.SetPosition(1, hit.point);
            }
        }
        else
        {
            lRenderer.SetPosition(0, transform.position);
            lRenderer.SetPosition(1, transform.position);
        }

        //Animation controls
        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetBool("Attacking", IsEngaged && InRange());
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(CharacterName + " H: " + MaxHealth + "/" + CurrentHealth);
        sb.AppendLine("-Enemy: " + MyEnemy + "Eng: " + IsEngaged + " Rng: " + InRange());
        sb.AppendLine("-Dist: " + agent.remainingDistance);
        return sb.ToString();
    }


    #region Combat

    private bool InRange()
    {
        if (MyEnemy == null)
            return false;
        if (agent.remainingDistance <= CombatHelper.GetCombatDistance(this, MyEnemy))
            return true;
        return false;
    }

    #endregion

    #region Actions
    public void GoTo(Vector3 destination)
    {
        agent.SetDestination(destination);
        agent.stoppingDistance = 0;
        IsEngaged = false;
        print("going to: " + destination);
    }

    public void UsePrimarySkill()
    {
        print(CharacterName + "used: " + PrimarySkill.Name + "(PS)");
    }

    public void UseSecondarySkill()
    {
        print(CharacterName + "used: " + SecondarySkill.Name + "(SS)");
    }

    public void Engage(Enemy enemy)
    {
        agent.SetDestination(enemy.Position);
        agent.stoppingDistance = CombatHelper.GetCombatDistance(this, enemy);
        agent.autoBraking = true;
        IsEngaged = true;
        MyEnemy = enemy;
        print(CharacterName + " Engaging: " + enemy.EnemyName + " Stop: " + CombatHelper.GetCombatDistance(this, enemy));
    }

    private void Assist(Character character)
    {
        //TODO: Implement for healers.
        print("Assisting: " + character.CharacterName);
    }
    #endregion

    #region Drag controls
    void OnMouseDrag()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            OnDragRelease();
            isDragging = false;
        }
    }

    private void OnDragRelease()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
        {
            if (ClickHelper.IsUIClick())
                return;
            if (ClickHelper.IsCharacter(hit))
            {
                Assist(hit.transform.GetComponent<Character>());
            }
            else if (ClickHelper.IsEnemy(hit))
            {
                Engage(hit.transform.GetComponent<Enemy>());
            }
            else if (ClickHelper.IsTerrain(hit))
            {
                GoTo(hit.point);
            }
        }
    }
    #endregion


}
