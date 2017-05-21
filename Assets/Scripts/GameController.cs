using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour
{
    public enum State
    {
        Idle,
        CharacterSelected,
        MovingTo,
        Engaging
    }

    //public State PlayerState = State.Idle;
    public static GameController Handle;
    private bool waitingForDecision = false;
    public PlayerCollection Characters;
    public EnemyCollection Enemies;
    public GameConfiguration Configuration;

    void Awake()
    {
        if (Handle == null)
            Handle = this;
        else if (Handle != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Characters = new GameObject("Players").AddComponent<PlayerCollection>();
        Characters.gameObject.transform.SetParent(transform);
        GameObject temp;

        for (int i = 0; i < Configuration.Characters.Length; i++)
        {
            temp = Configuration.Characters[i].Create();
            temp.transform.position = StageManager.Instance.CharacterSpawnPositions[i];
        }


        Enemies = new GameObject("Enemies").AddComponent<EnemyCollection>();
        Enemies.gameObject.transform.SetParent(transform);

        for (int i = 0; i < Configuration.Enemies.Length; i++)
        {
            temp = Configuration.Enemies[i].Create();
            temp.transform.position = StageManager.Instance.EnemySpawnPositions[i];
        }


    }

    void Update()
    {
        /*RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (waitingForDecision)
                return;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
            {
                if (ClickHelper.IsUIClick())
                    return;
                if (ClickHelper.IsCharacter(hit))
                {
                    Players.ActiveCharacter = hit.transform.GetComponent<Character>();
                }
                else if (ClickHelper.IsTerrain(hit))
                {
                    Players.ActiveCharacter = null;
                }
            }
        }*/
    }

    public void AddCharacter(Character character)
    {
        Characters.AddPlayer(character);
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.AddEnemy(enemy);
    }

    #region Character Controlls

    /*public void UsePrimarySkill()
    {
        if (Players.ActiveCharacter != null)
        {
            Players.ActiveCharacter.UsePrimarySkill();
        }
    }*/

    /*public void UseSecondarySkill()
    {
        if (Players.ActiveCharacter != null)
        {
            Players.ActiveCharacter.UseSecondarySkill();
        }
    }*/

    /*public void StartGoTo()
    {
        if (Players.ActiveCharacter != null)
        {
            StartCoroutine(_GoTo(Players.ActiveCharacter));
        }
    }*/

    IEnumerator _GoTo(Character selChar)
    {
        while (true)
        {
            waitingForDecision = true;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
                {
                    if (!ClickHelper.IsUIClick() && ClickHelper.IsTerrain(hit))
                    {
                        selChar.GoTo(hit.point);
                        waitingForDecision = false;
                        break;
                    }
                }
                waitingForDecision = false;
                break;
            }
            yield return null;
        }
    }

    /*public void StartEngage()
    {
        if (Players.ActiveCharacter != null)
        {
            StartCoroutine(_StartEngage(Players.ActiveCharacter));
        }
    }*/

    IEnumerator _StartEngage(Character selChar)
    {
        while (true)
        {
            waitingForDecision = true;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10000))
                {
                    if (ClickHelper.IsEnemy(hit))
                    {
                        selChar.Engage(hit.transform.GetComponent<Enemy>());
                        waitingForDecision = false;
                        break;
                    }
                }
                waitingForDecision = false;
                break;
            }
            yield return null;
        }
    }

    #endregion
}
