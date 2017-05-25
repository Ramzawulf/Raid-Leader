using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour {

        public string EnemyName;
        public float HitBoxRadius = 2;

        public Vector3 Position { get { return transform.position; } set { } }

        public static List<Enemy> Collection;

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
