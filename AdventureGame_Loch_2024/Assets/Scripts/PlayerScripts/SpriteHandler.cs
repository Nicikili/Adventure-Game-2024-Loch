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
	public bool canStealPart = false;

	public PlayerStats ScriptStats;

	public void Start()
	{
		//Important note, if you want to change Variables, add the base value here.
		//This Script will make changes on the Prefab that stay otherwise.
		ScriptStats.JumpPower = 0;
		ScriptStats.GroundBaseSpeed = 20;
		ScriptStats.ExtraConstantGravity = 120;

		ScriptStats.MaxAirJumps = 0;
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

			if (spriteNameBodyPart == "S_Wing1")
			{
				ScriptStats.JumpPower = 80;
				ScriptStats.GroundBaseSpeed = 30;
			}

			if (spriteNameBodyPart == "S_Wing2")
			{
				ScriptStats.JumpPower = 120;
				ScriptStats.GroundBaseSpeed = 40;
			}

			if (spriteNameBodyPart == "S_Wing3")
			{
				ScriptStats.JumpPower = 100;
				ScriptStats.GroundBaseSpeed = 50;
				ScriptStats.ExtraConstantGravity = 0;
			}

			if (spriteNameBodyPart == "Tongue1"|| spriteNameBodyPart == "Tongue2")
			{
				canStealPart = true;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{

	}
}