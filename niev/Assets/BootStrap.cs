using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class BootStrap : MonoBehaviour
{
	public const int DEFAULT_KNIFE_DAMAGE = 1;
	public const float DEFAULT_KNIFE_SPEED = 750f;

	public Knife defaultKnife;

	private void Awake()
	{
		SetupPlayerSettings();
	}

	private void SetupPlayerSettings()
	{
		if (SceneManager.GetActiveScene().name != "Bootstrap" && (!PlayerPrefs.HasKey("PlayerData") || !PlayerPrefs.HasKey("SetupName")))
		{
			LoadBootstrap();
			return;
		}

		if (!PlayerPrefs.HasKey("PlayerData"))
		{
			CreatePlayerData();
		}

		if (PlayerPrefs.HasKey("PlayerData") && SceneManager.GetActiveScene().name == "Bootstrap" && PlayerPrefs.HasKey("SetupName"))
		{
			LoadGame();
		}
	}

	private void CreatePlayerData()
	{
		var data = new PlayerData();

		data.knifeDamage = DEFAULT_KNIFE_DAMAGE;
		data.knifeLaunchSpeed = DEFAULT_KNIFE_SPEED;
		data.playerKnife = defaultKnife;

		DataManager.Save(data);
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
	}

	private void LoadBootstrap()
	{
		SceneManager.LoadScene("Bootstrap");
	}
}
