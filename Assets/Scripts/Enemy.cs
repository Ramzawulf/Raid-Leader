using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour {

        public string EnemyName;
        public float HitBoxRadius = 2;

        public Vector3 Position { get { return transform.position; } set { } }

        void Awake() {
        }

        // Use this for initialization
        void Start () {
            GameController.Handle.AddEnemy (this);
        }

        // Update is called once per frame
        void Update () {
	
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, HitBoxRadius);
        }
    }
}
