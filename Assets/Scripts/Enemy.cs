using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public string Name;
    public float HitBoxRadius = 2;

    public Vector3 Position { get { return transform.position; } set { } }

    void Awake() {
        name = Name;
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
