using UnityEngine;
using System.Collections;

public class CapsuleCollider2DResizer : MonoBehaviour
{
	public CapsuleCollider2D capsuleCollider;
	public float targetSizeX = 2.0f;
	public float targetSizeY = 1.0f;
	public float duration = 1.0f; // Duration for the lerp
	public GameObject targetObject; // The object whose active state we're checking

	private Vector2 initialSize;

	void Start()
	{
		if (capsuleCollider == null)
		{
			capsuleCollider = GetComponent<CapsuleCollider2D>();
		}

		initialSize = capsuleCollider.size;
	}

	void Update()
	{ 
		if (targetObject != null)
		{
			if (targetObject.activeSelf)
			{
				StopAllCoroutines();
				StartCoroutine(LerpColliderSize(new Vector2(targetSizeX, targetSizeY)));
			}
			else
			{
				StopAllCoroutines();
				StartCoroutine(LerpColliderSize(initialSize));
			}
		}
	}

	private IEnumerator LerpColliderSize(Vector2 targetSize)
	{
		float timeElapsed = 0.0f;
		Vector2 startSize = capsuleCollider.size;

		while (timeElapsed < duration)
		{
			capsuleCollider.size = Vector2.Lerp(startSize, targetSize, timeElapsed / duration);
			timeElapsed += Time.deltaTime;
			yield return null;
		}

		// Ensure the final values are set
		capsuleCollider.size = targetSize;
	}
}