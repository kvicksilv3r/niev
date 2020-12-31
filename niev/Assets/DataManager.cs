using Newtonsoft.Json;
using UnityEngine;

public static class DataManager
{
	public static PlayerData Load()
	{
		var dataString = PlayerPrefs.GetString("PlayerData");
		var data = JsonConvert.DeserializeObject(dataString, typeof(PlayerData)) as PlayerData;
		return data;
	}

	public static void Save(PlayerData data)
	{
		var dataString = JsonConvert.SerializeObject(data);
		PlayerPrefs.SetString("PlayerData", dataString);
	}
}
