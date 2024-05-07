using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
	public SpriteRenderer spriteRendererWingL; //Wing L
	public Sprite[] spriteArrayWingL;
	public SpriteRenderer spriteRendererWingR; //Wing R
	public Sprite[] spriteArrayWingR;

	public SpriteRenderer spriteRendererLegL; //Leg L
	public Sprite[] spriteArrayLegL;
	public SpriteRenderer spriteRendererLegR; //Leg R
	public Sprite[] spriteArrayLegR;

	void Start()
	{
		spriteRendererWingL = gameObject.GetComponent<SpriteRenderer>();
		spriteRendererWingR = gameObject.GetComponent<SpriteRenderer>();
		spriteRendererLegL = gameObject.GetComponent<SpriteRenderer>();
		spriteRendererLegR = gameObject.GetComponent<SpriteRenderer>();
	}
	void ChangeSprite()
	{
		spriteRendererWingL.sprite = spriteArrayWingL[0];
		spriteRendererWingR.sprite = spriteArrayWingR[0];
		spriteRendererLegL.sprite = spriteArrayLegL[0];
		spriteRendererLegR.sprite = spriteArrayLegR[0];
	}
}
