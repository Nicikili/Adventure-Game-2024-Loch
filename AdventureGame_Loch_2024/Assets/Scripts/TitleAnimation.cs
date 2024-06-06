using UnityEngine;
using DG.Tweening;
using TMPro; // Import TextMeshPro namespace

public class TitleAnimationTMP : MonoBehaviour
{
	public TextMeshProUGUI titleText; // Reference to the TextMeshProUGUI component
	public float fadeInDuration = 1f;
	public float wiggleDuration = 1f;
	public float wiggleStrength = 20f;
	public int wiggleVibrato = 10;
	public float wiggleRandomness = 90f;

	void Start()
	{
		// Ensure the title is initially invisible
		Color originalColor = titleText.color;
		originalColor.a = 0f;
		titleText.color = originalColor;

		// Fade in the title
		titleText.DOFade(1f, fadeInDuration);
	}
}
