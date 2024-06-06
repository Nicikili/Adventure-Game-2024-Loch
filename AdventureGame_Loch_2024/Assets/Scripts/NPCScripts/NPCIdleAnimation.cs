using UnityEngine;
using DG.Tweening;

public class IdleAnimation : MonoBehaviour
{
	public float moveAmount = 0.5f; // Amount to move up and down
	public float moveDuration = 1f; // Duration of the move up and down
	public float rotateAmount = 5f; // Amount to rotate
	public float rotateDuration = 1f; // Duration of the rotation

	void Start()
	{
		StartIdleAnimation();
	}

	void StartIdleAnimation()
	{
		// Get the original position and rotation of the GameObject
		Vector3 originalPosition = transform.position;
		Quaternion originalRotation = transform.rotation;

		// Sequence for the idle animation
		Sequence idleSequence = DOTween.Sequence();

		// Move up and down
		idleSequence.Append(transform.DOMoveY(originalPosition.y + moveAmount, moveDuration).SetEase(Ease.InOutSine))
					.Append(transform.DOMoveY(originalPosition.y - moveAmount, moveDuration).SetEase(Ease.InOutSine))
					.Append(transform.DOMoveY(originalPosition.y, moveDuration).SetEase(Ease.InOutSine));

		// Rotate back and forth
		idleSequence.Join(transform.DORotate(new Vector3(0, 0, rotateAmount), rotateDuration).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo))
					.Join(transform.DORotate(new Vector3(0, 0, -rotateAmount), rotateDuration).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo))
					.Join(transform.DORotate(new Vector3(0, 0, 0), rotateDuration).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo));

		// Loop the entire sequence
		idleSequence.SetLoops(-1);
	}
}