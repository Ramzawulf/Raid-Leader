using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CombatHelper{

	public static float GetCombatDistance(Character attacker, Enemy target) {
        return attacker.MyAttack.Range + attacker.HitBoxRadius + target.HitBoxRadius;
    }
}
