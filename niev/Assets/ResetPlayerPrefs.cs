using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

class ResetPlayerPrefs : EditorWindow
{
	[MenuItem("Niev/Reset player prefs")]
	private static void ResetPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("Prefs flushed");
	}
}