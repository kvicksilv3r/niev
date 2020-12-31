using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
	public List<GameObject> activeKnives = new List<GameObject>();

	private KnifeLogic currentKnife;

	public GameObject knifePrefab;

	public Transform knifeAnchor;

	private PlayerData data;

	private int remainingKnives;

	void Start()
	{
		remainingKnives = 6;
		data = DataManager.Load();
		ReloadKnife();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (remainingKnives > 0)
			{
				LaunchKnife();
				ReloadKnife();
			}
		}
	}

	private void LaunchKnife()
	{
		currentKnife.FireKnife();
		remainingKnives--;
		currentKnife = null;
	}

	private void ReloadKnife()
	{
		if (remainingKnives > 0)
		{
			SpawnKnife();
		}
	}

	private void SpawnKnife()
	{
		var knifeObj = Instantiate(knifePrefab, knifeAnchor.position, Quaternion.identity);
		currentKnife = knifeObj.GetComponent<KnifeLogic>();
		activeKnives.Add(knifeObj);
		currentKnife.InitializeKnife(data);
	}
}
