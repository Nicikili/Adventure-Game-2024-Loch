using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
	public SpriteRenderer spriteRenderer; //Change Sprites of Berb
	public Sprite[] spriteArray;

	void Start()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	void ChangeSprite()
	{
		spriteRenderer.sprite = spriteArray[0];
	}
}
