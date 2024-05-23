using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
	private float horizontal; //keeps track of the direction we are going
	private bool isFacingRight = true;

	void Awake()
	{

	}

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		Flip();
	}

	void Flip()
	{
		if (!isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}
}
