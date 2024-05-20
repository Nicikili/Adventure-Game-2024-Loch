using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerController;

public class PlayerController : MonoBehaviour
{
    InputSystem controls;
	/*public SpriteHandler ScriptSpriteHandler;*/


	[SerializeField] private float playerSpeed = 20f; //Player Speed
	[SerializeField] private float jumpingPower = 26f;
    private float horizontal; //keeps track of the direction we are going
	private bool isFacingRight = true;

    private Rigidbody2D rbPlayer; //is the Rigidbody of our Player
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;

	private bool isInteracting = false;
	private bool isTalking = false;
	private bool unlockedNewBodyPart = false;

	public CapsuleCollider2DResizer ScriptCapsuleColliderResizer;
	[SerializeField] public bool noLegs = true;
	private bool isRolling = false;
	public float rollDuration = 1.0f; // Duration for one complete roll

	public Sprite Body;

	void Awake()
    {
		#region Input System
		controls = new InputSystem();

		controls.Player.Enable();

		controls.Player.Jump.started += ctx => JumpStart();
		controls.Player.Jump.canceled += ctx => JumpRelease();
		controls.Player.Accept.performed += ctx => Accept();

        controls.Player.Move.performed += ctx => Move();
		controls.Player.Move.started += ctx => StartRolling();
		controls.Player.Move.canceled += ctx => StopRolling();
		#endregion

		rbPlayer = GetComponent<Rigidbody2D>(); //Assign Rigidbody Component
		ScriptCapsuleColliderResizer = GetComponent<CapsuleCollider2DResizer>();
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
		isInteracting = true;
		/*ScriptSpriteHandler.ChangeSprite();*/
		Debug.Log("ChangeSprite");

	}

	void Move()
	{
	
	}

	void StartRolling()
	{
		if (noLegs == true)
		{
			transform.DORotate(new Vector3(0, 0, 360), rollDuration, RotateMode.FastBeyond360)
			.SetRelative()
			.SetLoops(-1, LoopType.Restart);
		}
	}

	private void StopRolling()
	{
		transform.DOKill();
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
	#endregion

	// Enable and Disable Controls
	#region Control Manager 
	void OnEnable()
	{
		controls.Player.Enable();
	}

	void OnDisable()
	{
		controls.Player.Disable();
	}

	void CheckForInteraction()
	{
		if (isTalking)
		{
			controls.Player.Accept.Enable();
		}

		if (!isTalking)
		{
			controls.Player.Accept.Disable();
		}

		if (unlockedNewBodyPart)
		{
			controls.Player.Accept.Enable();
		}

		if (!unlockedNewBodyPart)
		{
			controls.Player.Accept.Disable();
		}
	}
	#endregion

	#region Collisions

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "TalkToNPC")
		{
			isTalking = true;
		}

		if (other.tag == "NewBodyPart")
		{
			unlockedNewBodyPart = true;

			if (isInteracting)
			{
				Sprite tempTarget = this.GetComponentInChildren<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite; //for newBodyParts
																																		//Sprite tempTarget = other.GetComponent<SpriteRenderer>().sprite = newBodyPartSprite;


				if (string.Compare(this.GetComponentInChildren<SpriteRenderer>().name, other.GetComponent<SpriteRenderer>().sprite.name) == 0)
				{
					Debug.Log("Hello");
				}
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "TalkToNPC")
		{
			isTalking = false;
		}

		if (other.tag == "NewBodyPart")
		{
			unlockedNewBodyPart = false;
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
		CheckForInteraction();
	}

	bool isGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}
}
