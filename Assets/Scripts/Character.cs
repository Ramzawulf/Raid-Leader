using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(LineRenderer))]
public class Character : MonoBehaviour
{
    private LineRenderer lRenderer;
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
    private bool isDragging;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed;
        GameController.Handle.AddCharacter(this);
        lRenderer = GetComponent<LineRenderer>() ?? gameObject.AddComponent<LineRenderer>();
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
    }

    #region Actions
    public void GoTo(Vector3 destination)
    {
        agent.SetDestination(destination);
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
        print("Engaging: " + enemy.Name + " Stop: " + CombatHelper.GetCombatDistance(this, enemy));
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
