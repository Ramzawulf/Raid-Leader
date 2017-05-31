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

            for (var i = 0; i < Configuration.Raiders.Length; i++)
            {
                GameObject temp = Configuration.Raiders[i].Create();
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
    }
}