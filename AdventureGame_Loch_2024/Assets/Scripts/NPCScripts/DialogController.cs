using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogController : MonoBehaviour
{
	public TextMeshProUGUI DialogText;
	public string[] Sentences;
	private int Index = 0;
	public float DialogSpeed;
	public Animator DialogAnimator;
	private bool StartDialog = true;

	protected bool textDebounce;

	//public GameObject talkMenu;
	public GameObject textBox;


	public GameObject npcTalks;

	//deactivate narrator while you talk to NPCs
	public bool narratorTalks = false;


	// Update is called once per frame
	public void Update()
	{
		if (Gamepad.current.aButton.wasPressedThisFrame && !textDebounce) //continue currently on b button because of my weird controller (normaly on a)
		{
			textDebounce = true;

			if (StartDialog)
			{   //animation start
				//DialogAnimator.SetTrigger("Enter");
				textBox.SetActive(true);
				StartDialog = false;
				textDebounce = false;
			}

			else
			{ //if button pressed again, start sentence
				NextSentence();
				Debug.Log("Hello");
			}
		}
	}

	void NextSentence()
	{
		if (Index <= Sentences.Length - 1)
		{
			DialogText.text = "";
			StartCoroutine(WriteSentence());
		}

		else
		{ //animation end
			DialogText.text = "";
			//DialogAnimator.SetTrigger("Exit");
			textBox.SetActive(false);

			npcTalks.SetActive(false);

			Index = 0;
			StartDialog = true;
		}
	}


	IEnumerator WriteSentence()
	{ //dialog (Laurin helped me here! Thanks again Laurin! :D)

		//char[] characters = Sentences[Index].ToCharArray();
		char[] characters = Sentences[Index].ToCharArray();

		for (int i = 0; i < characters.Length; ++i)
		{
			DialogText.text += characters[i];
			yield return new WaitForSeconds(DialogSpeed);
			if (i >= characters.Length - 1) textDebounce = false;
		}
		Index++;
		Debug.Log("Hello");

	}
}

