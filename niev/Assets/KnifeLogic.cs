using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLogic : MonoBehaviour
{
	public Transform knifeGraphicAnchor;

	private Rigidbody rigidbody;

	private float knifeLaunchForce;

	public void InitializeKnife(PlayerData data)
	{
		SetupKnife(data);
	}

	public void FireKnife()
	{
		SetKinematic(false);
		rigidbody.AddForce(Vector3.up * knifeLaunchForce);
	}

	private void SetKinematic(bool isKinematic = true)
	{
		rigidbody.isKinematic = isKinematic;
	}

	private void AttachKnife(Transform parent)
	{
		transform.parent = parent;
	}

	private void OnCollisionEnter(Collision collision)
	{
		var other = collision.gameObject;
		tag = other.tag;

		switch (tag)
		{
			case "Target":
				AttachKnife(other.transform);
				SetKinematic(true);
				break;
		}
	}

	private void SetupKnife(PlayerData data)
	{
		rigidbody = GetComponent<Rigidbody>();
		var knife = data.playerKnife;

		var knifeGfx = Resources.Load<GameObject>(knife.knifeGraphicPath);
		Instantiate(knifeGfx, knifeGraphicAnchor);

		knifeLaunchForce = data.knifeLaunchSpeed;
	}
}
