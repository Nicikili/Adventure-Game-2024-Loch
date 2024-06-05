using UnityEngine;
using DG.Tweening;

public class FloatingAnimation : MonoBehaviour
{
	public float floatHeight = 0.5f;  // The distance to move up and down
	public float floatDuration = 2.0f; // The duration for one complete float cycle

	private Vector3 originalPosition;

	private void Start()
	{
		// Save the original position of the GameObject
		originalPosition = transform.position;

		// Start the floating animation
		StartFloating();
	}

	private void StartFloating()
	{
		// Create the floating effect by moving up and down repeatedly
		transform.DOMoveY(originalPosition.y + floatHeight, floatDuration)
				 .SetEase(Ease.InOutSine)
				 .SetLoops(-1, LoopType.Yoyo);
	}

	private void OnDisable()
	{
		// Ensure the animation stops if the GameObject is disabled
		transform.DOKill();
		transform.position = originalPosition;
	}
}