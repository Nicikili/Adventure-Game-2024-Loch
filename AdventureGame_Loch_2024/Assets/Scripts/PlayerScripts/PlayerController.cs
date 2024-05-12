using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerController;

public class PlayerController : MonoBehaviour
{
    InputSystem controls;
	public SpriteHandler ScriptSpriteHandler;

		[SerializeField] private float playerSpeed = 20f; //Player Speed
	[SerializeField] private float jumpingPower = 26f;
    private float horizontal; //keeps track of the direction we are going
	private bool isFacingRight = true;

    private Rigidbody2D rbPlayer; //is the Rigidbody of our Player
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;

	void Awake()
    {
		#region Input System
		controls = new InputSystem();

		controls.Player.Enable();

		controls.Player.Jump.started += ctx => JumpStart();
		controls.Player.Jump.canceled += ctx => JumpRelease();
		controls.Player.Accept.performed += ctx => Accept();
        controls.Player.Move.performed += ctx => Move();
		#endregion

		rbPlayer = GetComponent<Rigidbody2D>(); //Assign Rigidbody Component
	}

	#region Player Controls

	void JumpStart()
    {
		if (isGrounded())
		{
			rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpingPower);
		}
	}
	void JumpRelease()
	{
		if (rbPlayer.velocity.y > 0f)
		{
			rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, rbPlayer.velocity.y * 0.5f);
		}
	}

	void Accept()
	{
		ScriptSpriteHandler.ChangeSprite();
	}

	void Move()
	{

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

	void OnEnable()
	{
		controls.Player.Enable();
	}

	void OnDisable()
	{
		controls.Player.Disable();
	}
	#endregion

	#region Collisions

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "TalkToNPC")
		{

		}

		if (other.tag == "NewBodyPart")
		{

		}
	}
	#endregion

	private void FixedUpdate()
	{
		rbPlayer.velocity = new Vector2(horizontal * playerSpeed, rbPlayer.velocity.y);
	}

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		Flip();
	}

	bool isGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}
}
