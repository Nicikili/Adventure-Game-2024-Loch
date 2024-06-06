using UnityEngine;
using DG.Tweening;

public class MoveDown : MonoBehaviour
{
	public float targetYPositionDOWN = -5f; // Target y-coordinate
	public float targetYPositionUP = +5f;
	public float duration = 1f; // Duration of the movement

	void Start()
	{
		MoveGameObjectDown();
		MoveGameObjectUp();
	}

	void MoveGameObjectDown()
	{
		// Move the GameObject's y position to the target value over the specified duration
		transform.DOMoveY(targetYPositionDOWN, duration).SetEase(Ease.InOutSine);
	}

	void MoveGameObjectUp()
	{
		// Move the GameObject's y position to the target value over the specified duration
		transform.DOMoveY(targetYPositionUP, duration).SetEase(Ease.InOutSine);
	}
}