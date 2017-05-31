using UnityEngine.Serialization;

[System.Serializable]
public class GameConfiguration
{
    public RaiderConfiguration[] Raiders;
    public EnemyConfiguration[] Enemies;
    private static string CONFIG_KEY = "CONFIGURATION_KEY";
}
