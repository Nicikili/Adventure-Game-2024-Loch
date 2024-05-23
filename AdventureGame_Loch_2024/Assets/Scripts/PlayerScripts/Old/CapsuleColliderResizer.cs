using UnityEngine;
using System.Collections;

public class CapsuleCollider2DResizer : MonoBehaviour
{
	public CapsuleCollider2D capsuleCollider;
	public float targetOffsetY = 0.9f;
	public float targetSizeY = 7.4f;

	const float startSizeX = 7.2f;
	const float startOffsetX = 3.7f;

	public float duration = 1.0f; // Duration for the lerp
	public GameObject targetObject; // The object whose active state we're checking


	public PlayerController ScriptPlayerController;

	private Vector2 CapsuleSizeWithLegs;
	private Vector2 CapsuleSizeNoLegs;

	void Start()
	{

		ScriptPlayerController = GetComponent<PlayerController>();

		if (capsuleCollider == null)
		{
			capsuleCollider = GetComponent<CapsuleCollider2D>();
		}

		Vector2 startSize = capsuleCollider.size;

		if (ScriptPlayerController.noLegs == true)
		{
			CapsuleSizeWithLegs = new Vector2(startSizeX, targetSizeY);
			CapsuleSizeNoLegs = new Vector2(startOffsetX, targetOffsetY);
		}
	}

	void Function()
	{
		capsuleCollider.size = CapsuleSizeWithLegs;
		capsuleCollider.offset = CapsuleSizeNoLegs;
	}
}