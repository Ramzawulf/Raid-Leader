using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public int partySize = 4;
    public int enemySize = 5;
    public static StageManager Instance;
    public float spawningRadius;
    public Vector3[] CharacterSpawnPositions
    {
        get { return GetCharacterSpawnpoints(); }
    }
    public Vector3[] EnemySpawnPositions { get { return GetEnemySpawnPoints(); } }
    public Transform CharacterStartPosition;
    public Transform EnemyStartPosition;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private Vector3[] GetCharacterSpawnpoints()
    {
        var result = new Vector3[partySize];
        float degrees = 360 / partySize;

        for (int i = 0; i < partySize; i++)
        {
            float x, y, z;

            x = spawningRadius * Mathf.Cos(Mathf.Deg2Rad * degrees * i) + CharacterStartPosition.position.x;
            y = CharacterStartPosition.position.y;
            z = spawningRadius * Mathf.Sin(Mathf.Deg2Rad * degrees * i) + CharacterStartPosition.position.z;

            result[i] = new Vector3(x, y, z);
        }

        return result;
    }

    private Vector3[] GetEnemySpawnPoints()
    {
        var result = new Vector3[enemySize + 1];
        result[0] = EnemyStartPosition.position;
        float degrees = 360 / enemySize;

        for (int i = 1; i <= enemySize; i++)
        {
            float x, y, z;

            x = spawningRadius * Mathf.Cos(Mathf.Deg2Rad * degrees * i) + EnemyStartPosition.position.x;
            y = EnemyStartPosition.position.y;
            z = spawningRadius * Mathf.Sin(Mathf.Deg2Rad * degrees * i) + EnemyStartPosition.position.z;

            result[i] = new Vector3(x, y, z);
        }
        return result;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (var pos in GetCharacterSpawnpoints())
        {
            Gizmos.DrawWireSphere(pos, 0.2f);
        }

        Gizmos.color = Color.red;
        foreach (var pos in GetEnemySpawnPoints())
        {
            Gizmos.DrawWireSphere(pos, 0.2f);
        }
    }
}
