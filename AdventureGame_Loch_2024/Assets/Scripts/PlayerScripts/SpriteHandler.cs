using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class SpriteHandler : MonoBehaviour
{
	public GameObject findSwitchTargetIn;
	public string tagToCompare;

	public void OnTriggerEnter2D(Collider2D other)
	{
		tagToCompare = other.tag;

		foreach (Transform child in findSwitchTargetIn.transform)
		{
			if (child.CompareTag(tagToCompare))
			{
				Sprite tempTarget = child.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{

	}
}