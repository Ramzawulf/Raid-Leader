using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(CanvasGroup))]
public class CharacterPanel : MonoBehaviour
{

	public Image Portrait;
	public Text CharacterName;
	public ResourceBar HealthBar;
	public Button PrimarySkill;
	public Button SecondarySkill;
	public Button GoTo;
	public Button Engage;
	public float transitionSpeed = 0.5f;
	private Character boundCharacter;
	private CanvasGroup cGroup;

	public void  Awake ()
	{
		cGroup = GetComponent<CanvasGroup> ();
		cGroup.alpha = 0;
	}

	public void Start ()
	{
		/*PrimarySkill.onClick.AddListener (() => {
			GameController.Handle.UsePrimarySkill ();
		});
		SecondarySkill.onClick.AddListener (() => {
			GameController.Handle.UseSecondarySkill ();
		});
		GoTo.onClick.AddListener (() => {
			GameController.Handle.StartGoTo ();
		});
		Engage.onClick.AddListener (() => {
			GameController.Handle.StartEngage ();
		});*/

	}

	public void Show ()
	{
		StartCoroutine (_Show ());
	}

	IEnumerator _Show ()
	{
		while (cGroup.alpha < 1) {
			cGroup.alpha = Mathf.Max (cGroup.alpha + transitionSpeed * Time.time, 1);
			yield return null;
		}
	}

	public void Hide ()
	{
		StartCoroutine (_Hide ());
	}

	IEnumerator _Hide ()
	{
		while (cGroup.alpha > 0) {
			cGroup.alpha = Mathf.Max (cGroup.alpha - transitionSpeed * Time.time, 0);
			yield return null;
		}
	}

	public void Bind (Character character)
	{
		boundCharacter = character;
		Portrait.sprite = character.Portrait;
		CharacterName.text = character.CharacterName;
		HealthBar.MaxValue = character.MaxHealth;
		HealthBar.CurrentValue = character.CurrentHealth;
		//Primary Skill Setup
		//PrimarySkill.transform.Find ("Text").GetComponent<Text> ().text = character.PrimarySkill.Name;
		PrimarySkill.GetComponent<Image> ().sprite = character.PrimarySkill.Icon;
		//Secondary Skill Setup
		//SecondarySkill.transform.Find ("Text").GetComponent<Text> ().text = character.SecondarySkill.Name;
		SecondarySkill.GetComponent<Image> ().sprite = character.SecondarySkill.Icon;
	}

	public void Unbind ()
	{
		boundCharacter = null;
		Portrait.sprite = null;
		CharacterName.text = string.Empty;
		HealthBar.MaxValue = 0;
		HealthBar.CurrentValue = 0;
		//Primary Skill Setup
		//PrimarySkill.transform.Find ("Text").GetComponent<Text> ().text = character.PrimarySkill.Name;
		PrimarySkill.GetComponent<Image> ().sprite = null;
		//Secondary Skill Setup
		//SecondarySkill.transform.Find ("Text").GetComponent<Text> ().text = character.SecondarySkill.Name;
		SecondarySkill.GetComponent<Image> ().sprite = null;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//TODO: Keep skill cooldown displayed
	}
}
