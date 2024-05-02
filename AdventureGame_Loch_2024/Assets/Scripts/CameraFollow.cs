using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;

	[SerializeField] int xAxis = 0; //CameraFollow for x Axis
	[SerializeField] int yAxis = 0; // Camera Follow for y Axis
	[SerializeField] int zAxis = 0; // Camera Follow for z Axis

	// Update is called once per frame
	void Update()
	{
		transform.position = player.transform.position + new Vector3(xAxis, yAxis, zAxis);
	}
}