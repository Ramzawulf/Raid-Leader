using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHelper{

	public static float GetCombatDistance(Character attacker, Enemy target) {
        return attacker.AttackRange + attacker.HitBoxRadius + target.HitBoxRadius + 10;
    }
}
