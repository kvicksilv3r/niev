using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Knife", menuName = "Niev/New knife", order = 1)]
public class Knife : ScriptableObject
{
	public string knifeName;
	public string knifeGraphicPath;
}
