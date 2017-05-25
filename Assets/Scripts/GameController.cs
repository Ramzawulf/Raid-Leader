using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public static GameController Handle;
        public GameConfiguration Configuration;
        public bool waitingForDecision;

        private void Awake()
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
            InitEnemies();
            InitRaiders();
        }
        

        private void InitRaiders()
        {
            GameObject container = new GameObject("Players");
            container.transform.SetParent(transform);

            for (var i = 0; i < Configuration.Characters.Length; i++)
            {
                var temp = Configuration.Characters[i].Create();
                temp.transform.position = StageManager.Instance.CharacterSpawnPositions[i];
                temp.transform.SetParent(container.transform);
            }
        }

        private void InitEnemies()
        {
            for (var i = 0; i < Configuration.Enemies.Length; i++)
            {
                var temp = Configuration.Enemies[i].Create();
                temp.transform.position = StageManager.Instance.EnemySpawnPositions[i];
            }

            GameObject container = new GameObject("Enemies");
            container.transform.SetParent(transform);
            if(Enemy.Collection != null && Enemy.Collection.Count > 0)
            {
                Enemy.Collection[0].SetHealthBar(UIController.Instance.BossHealthBar);
            }
        }

        private void Update()
        {
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

        private IEnumerator _GoTo(Character selChar)
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

        private IEnumerator _StartEngage(Character selChar)
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
}