using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceBar: MonoBehaviour
{
	//TODO: Pimp up to go into the asset store
	public Image ForeGround;
	public Image BackGround;
	public Text ValueLabel;

	public float MaxValue = 100;
	private float _currentValue;

	public void Awake ()
	{
		if (ForeGround == null)
			ForeGround = transform.FindChild ("Foreground").GetComponent<Image> ();
		if (BackGround == null)
			BackGround = transform.FindChild ("BackGround").GetComponent<Image> ();
		if (ValueLabel == null)
			ValueLabel = transform.FindChild ("ValueLabel").GetComponent<Text> ();
	}

	public float CurrentValue {
		get {
			return _currentValue;
		}
		set { 
			_currentValue = value;
			UpdateBar ();
		}
	}

	private void UpdateBar ()
	{
		if (MaxValue != 0)
			ForeGround.fillAmount = Mathf.Max (_currentValue / MaxValue);
		ValueLabel.text = string.Format ("{0}/{1}", CurrentValue, MaxValue);
	}
}

