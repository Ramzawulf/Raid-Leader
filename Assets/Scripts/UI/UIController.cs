using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
	public static UIController Handle;
	public CharacterPanel charPanel;

	void Awake ()
	{
		if (Handle == null)
			Handle = this;
		else if (Handle != this)
			Destroy (gameObject);
	}

	public void OnCharacerSelected (Character character)
	{
		charPanel.Show ();
		charPanel.Bind (character);
	}

	public void OnCharDeselected ()
	{
		charPanel.Hide ();
		charPanel.Unbind ();
	}

}
