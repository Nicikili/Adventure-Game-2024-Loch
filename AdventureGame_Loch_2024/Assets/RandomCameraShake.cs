using UnityEngine;
using DG.Tweening;
using System.Collections;

public class RandomCameraShake : MonoBehaviour
{
	public float shakeDuration = 0.5f; // Duration of each shake
	public float shakeStrength = 1f; // Strength of each shake
	public int shakeVibrato = 10; // Number of vibrations
	public float shakeRandomness = 90f; // Randomness of the shake
	public float minShakeInterval = 1f; // Minimum interval between shakes
	public float maxShakeInterval = 5f; // Maximum interval between shakes

	private void Start()
	{
		StartCoroutine(ShakeRoutine());
	}

	private IEnumerator ShakeRoutine()
	{
		while (true)
		{
			// Wait for a random amount of time between minShakeInterval and maxShakeInterval
			float waitTime = Random.Range(minShakeInterval, maxShakeInterval);
			yield return new WaitForSeconds(waitTime);

			// Perform the camera shake
			Camera.main.transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness);
		}
	}
}