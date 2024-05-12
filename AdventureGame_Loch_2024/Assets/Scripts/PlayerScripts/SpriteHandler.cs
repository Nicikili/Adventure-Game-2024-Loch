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

	public void Start()
	{
		spriteRendererWingL = gameObject.GetComponentInChildren<SpriteRenderer>();
		spriteRendererWingR = gameObject.GetComponentInChildren<SpriteRenderer>();
		spriteRendererLegL = gameObject.GetComponentInChildren<SpriteRenderer>();
		spriteRendererLegR = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
	public void ChangeSprite()
	{
		spriteRendererWingL.sprite = spriteArrayWingL[0];
		spriteRendererWingR.sprite = spriteArrayWingR[0];
		spriteRendererLegL.sprite = spriteArrayLegL[0];
		spriteRendererLegR.sprite = spriteArrayLegR[0];
		Debug.Log("Yee");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}

	public void Update()
	{
		ChangeSprite();
	}
}
