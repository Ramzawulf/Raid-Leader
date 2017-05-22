using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using Assets.Scripts;

public class UIController : MonoBehaviour
{
	public static UIController Instance;
    public Text Debug;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
	}

    public void Update()
    {
        StringBuilder message = new StringBuilder();

        for (int i = 0; i < GameController.Handle.Characters.Size; i++)
        {
            message.AppendLine(GameController.Handle.Characters[i].ToString());
        }

        Debug.text = message.ToString();
    }

    public void OnCharacerSelected (Character character)
	{

	}

	public void OnCharDeselected ()
	{
    }

}
