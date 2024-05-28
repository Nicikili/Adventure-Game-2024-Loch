using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class PulsatingAnimation : MonoBehaviour
{
	public float scaleFactor = 1.2f; // The maximum scale factor for the y-axis (mouth opening)
	public float duration = 0.3f;    // The duration of one open/close cycle
	public float moveDistance = 0.1f; // The maximum distance to move up and down
	public bool isTalking = false;    // Toggle to start or stop the talking animation

	[SerializeField] GameObject textBox;

	private Vector3 originalScale;
	private Vector3 originalPosition;

	private void Start()
	{
		// Save the original scale and position of the GameObject
		originalScale = transform.localScale;
		originalPosition = transform.localPosition;

		// Start the talking effect if isTalking is true
		if (isTalking)
		{
			StartTalking();
		}
	}

	private void StartTalking()
	{
		// Create a talking effect by scaling y up and down repeatedly
		transform.DOScaleY(originalScale.y * scaleFactor, duration)
				 .SetLoops(-1, LoopType.Yoyo)
				 .SetEase(Ease.InOutSine);

		// Create a whipping effect by moving up and down repeatedly
		transform.DOLocalMoveY(originalPosition.y + moveDistance, duration)
				 .SetLoops(-1, LoopType.Yoyo)
				 .SetEase(Ease.InOutSine);
	}

	public void StopTalking()
	{
		isTalking = false;
		// Stop the talking effect and reset the scale and position to the original
		transform.DOKill();  // Stop all active tweens on this transform
		transform.localScale = originalScale;
		transform.localPosition = originalPosition;
	}

	private void OnDisable()
	{
		// Ensure the animation stops if the GameObject is disabled
		StopTalking();
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		isTalking = true;
		StartTalking();
		textBox.SetActive(true);
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		isTalking = false;
		StopTalking();
		textBox.SetActive(false);
	}
}