using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class SpriteHandler : MonoBehaviour
{
	public GameObject findSwitchTargetIn;
	public string tagToCompare;

	public GameObject IK_BonesTarget;
	public string spriteNameBodyPart;

	public PlayerStats ScriptStats;

	public void Start()
	{
		ScriptStats.JumpPower = 0;
		ScriptStats.GroundBaseSpeed = 20;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		tagToCompare = other.tag;
        if (tagToCompare == "collectWing" || tagToCompare == "collectLeg" || tagToCompare == "collectTongue")
        {
			foreach (Transform child in findSwitchTargetIn.transform)
			{
				if (child.CompareTag(tagToCompare))
				{
					Sprite tempTarget = child.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
				}
			}

			spriteNameBodyPart = other.GetComponent<SpriteRenderer>().sprite.name;

			if (spriteNameBodyPart == "S_Wing2")
			{
				ScriptStats.JumpPower = 80; 
			}

			if (spriteNameBodyPart == "S_Wing1")
			{

			}
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{

	}
}