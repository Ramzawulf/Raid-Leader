using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Skill
{
	public enum TargetType
	{
		SingleEnemy,
		MultipleEnemies,
        Self,
        SingleAlly,
        MultipleAllies
	}

	public string Name;
	public string Description;
	public Sprite Icon;
	public float CoolDown;
	public TargetType Target;

	public float RemainingCoolDown {
		get	{ return Mathf.Max (0, Time.time - (lastUse + CoolDown)); }
		set{ }
	}

	public bool CanBeUsed {
		get{ return (RemainingCoolDown <= 0); }
		set{ }
	}

	private float lastUse = 0;
}

