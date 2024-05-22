using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class SpriteHandler : MonoBehaviour
{
	//public GameObject s_BerbBase;
	//public GameObject s_LegL;
	//public GameObject s_LegR;
	public GameObject s_WingL;
	//public GameObject s_WingR;

	//public GameObject Sprites;
	//public GameObject IK_Bones;

	//public SpriteResolver bodypartsSpriteResolver;

	public GameObject findSwitchTargetIn;

	public string tagToCompare;

	//https://www.youtube.com/watch?v=wBGykdKd80w&ab_channel=Tarodev
	private void Start()
	{

	}
	
	private void Update()
	{

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		tagToCompare = other.tag;

		foreach (Transform child in findSwitchTargetIn.transform)
		{
			if (child.CompareTag(tagToCompare))
			{
				Debug.Log("Found A Target!");
				Sprite tempTarget = child.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
			}
		}
		//if (string.Compare(S_LegR.BP_SpriteResovler.Category.Label.name, other.GetComponent<SpriteRenderer>().sprite.name) == 0)
	}

	public void OnTriggerExit2D(Collider2D other)
	{

	}
}