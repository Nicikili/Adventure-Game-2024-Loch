using UnityEngine;
using DG.Tweening;
using TMPro; // Import TextMeshPro namespace

public class UnderTitleAnimation : MonoBehaviour
{
	public TextMeshProUGUI underTitleText; // Reference to the TextMeshProUGUI component
	public float fadeInDuration = 1f;
	public float wiggleDuration = 1f;
	public float wiggleStrength = 20f;
	public int wiggleVibrato = 10;
	public float wiggleRandomness = 90f;

	void Start()
	{
		// Ensure the title is initially invisible
		Color originalColor = underTitleText.color;
		originalColor.a = 0f;
		underTitleText.color = originalColor;

		// Fade in the title
		underTitleText.DOFade(1f, fadeInDuration)
			.OnComplete(() =>
			{
				// Wiggle the title
				underTitleText.rectTransform.DOShakeAnchorPos(wiggleDuration, wiggleStrength, wiggleVibrato, wiggleRandomness)
					.OnComplete(() =>
					{
						// Title stands still at the end of the wiggle
					});
			});
	}
}
