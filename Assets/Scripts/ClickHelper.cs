using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClickHelper
{
	public enum ClickResult
	{
		Invalid,
		Character,
		Terrain,
		Enemy,
		UI
	}

	public static ClickResult GetClickResult (RaycastHit hit)
	{
		if (hit.transform.CompareTag ("Character"))
			return ClickResult.Character;
		if (hit.transform.CompareTag ("Terrain"))
			return ClickResult.Terrain;
		if (hit.transform.CompareTag ("Enemy"))
			return ClickResult.Enemy;
		if (EventSystem.current.IsPointerOverGameObject ())
			return ClickResult.UI;
		return ClickResult.Invalid;
	}

	public static bool IsUIClick ()
	{
		return EventSystem.current.IsPointerOverGameObject ();
	}

	public static bool IsTerrain (RaycastHit hit)
	{
		return hit.transform.CompareTag ("Terrain");
	}

	public static bool IsCharacter (RaycastHit hit)
	{
		return hit.transform.CompareTag ("Character");
	}
}
