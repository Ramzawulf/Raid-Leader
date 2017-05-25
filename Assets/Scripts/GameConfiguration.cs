using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameConfiguration
{
    public CharacterConfiguration[] Characters;
    public EnemyConfiguration[] Enemies;
    private static string CONFIG_KEY = "CONFIGURATION_KEY";
}
