using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameSetter : MonoBehaviour
{
	public TextMeshProUGUI welcomeText;

	public TMP_InputField inputField;

	public GameObject playButton;

	public void ApplyName()
	{
		if (inputField.text.Length > 0)
		{
			var data = DataManager.Load();
			data.playerName = inputField.text;
			DataManager.Save(data);
			PlayerPrefs.SetInt("SetupName", 1);

			welcomeText.text = $"Knife to meet you, {inputField.text}";

			playButton.SetActive(true);
		}

		else
		{
			welcomeText.text = "A name but contain atleast one character. Silly.";
		}
	}
}
