using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	public enum State
	{
		Idle,
		CharacterSelected,
		MovingTo,
		Engaging
	}

	public	Character[] characters;
	public State PlayerState = State.Idle;
	private int selCharIndex;
	public static PlayerController Handle;
	private bool waitingForDecision = false;

	void Awake ()
	{
		if (Handle == null)
			Handle = this;
		else if (Handle != this)
			Destroy (gameObject);
	}

	private Character selectedChar {
		get {
			if (characters != null && characters.Length >= selCharIndex && selCharIndex >= 0)
				return characters [selCharIndex];
			return null;
			
		}
		set {
			if (value == null) {
				selCharIndex = -1;
				UIController.Handle.OnCharDeselected ();
			} else {
				for (int i = 0; i < characters.Length; i++) {
					if (characters [i] == value) {
						selCharIndex = i;
						UIController.Handle.OnCharacerSelected (selectedChar);
					}
				}
			}
		}
	}

	void Update ()
	{
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
			if (waitingForDecision)
				return;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 10000)) {
				if (ClickHelper.IsUIClick ())
					return;
				if (ClickHelper.IsCharacter (hit)) {
					selectedChar = hit.transform.GetComponent<Character> ();
				} else if (ClickHelper.IsTerrain (hit)) {
					selectedChar = null;
				}
			}
		}
	}

	public void AddCharacter (Character character)
	{
		//Check if the char already exists
		for (int i = 0; i < characters.Length; i++) {
			if (characters [i] == character)
				return;
		}	
		var temp = new List<Character> ();
		temp.AddRange (characters);
		temp.Add (character);
		characters = temp.ToArray ();
	}

	#region Character Controlls

	public void UsePrimarySkill ()
	{
		if (selectedChar != null) {
			selectedChar.UsePrimarySkill ();
		}
	}

	public void UseSecondarySkill ()
	{
		if (selectedChar != null) {
			selectedChar.UseSecondarySkill ();
		}
	}

	public void StartGoTo ()
	{
		if (selectedChar != null) {
			StartCoroutine (_GoTo (selectedChar));
		}
	}

	IEnumerator _GoTo (Character selectedChar)
	{
		while (true) {
			waitingForDecision = true;
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 10000)) {
					if (!ClickHelper.IsUIClick () && ClickHelper.IsTerrain (hit)) {
						selectedChar.GoTo (hit.point);
						waitingForDecision = false;
						break;
					}
				}
				waitingForDecision = false;
				break;
			}
			yield return null;
		}
	}

	public void StartEngage ()
	{
		if (selectedChar != null) {
			StartCoroutine (_StartEngage (selectedChar));
		}
	}

	IEnumerator _StartEngage (Character selectedChar)
	{
		//TODO: implement
		return null;
	}

	#endregion
}
