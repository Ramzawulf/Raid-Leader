using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {

        public string EnemyName;
        public float HitBoxRadius = 2;
        public AttackBehaviour Attack;
        public float MaxHealth;
        public float CurrentHealth;
        public static List<Enemy> Collection;
        public Vector3 Position { get { return transform.position; } set { } }
        private HealthBar healthBar;

        public void SetHealthBar(HealthBar hBar) {
            healthBar = hBar;
            healthBar.MaxValue = MaxHealth;
            healthBar.CurrentValue = CurrentHealth;
            healthBar.BarName = EnemyName;
        }

        public void Damage(float damage)
        {
            CurrentHealth -= damage;
            healthBar.CurrentValue = CurrentHealth;
        }

        private void OnEnable()
        {
            if (Collection == null)
                Collection = new List<Enemy>();
            Collection.Add(this);
        }

        private void OnDisable()
        {
            Collection.Remove(this);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, HitBoxRadius);
        }
    }
}
