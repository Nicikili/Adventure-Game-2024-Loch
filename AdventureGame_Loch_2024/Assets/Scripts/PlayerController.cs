using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputSystem controls;

    private float playerSpeed = 20f; //Player Speed
    private float playerDirection; //keeps track of the direction we are going
    private Rigidbody2D rbPlayer; //is the Rigidbody of our Player

    void Awake()
    {
		#region Input System
		controls = new InputSystem();

		controls.Player.Enable();

		controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Accept.performed += ctx => Accept();
        controls.Player.Move.performed += ctx => Move();
		#endregion

		rbPlayer = GetComponent<Rigidbody2D>(); //Assign Rigidbody Component

    }

    #region Player Controls

    void Jump()
    {
        
    }

	void Accept()
	{

	}
	void Move()
	{

	}

	#endregion

	void OnEnable()
	{
        controls.Player.Enable();
	}
    
    void OnDisable()
    {
        controls.Player.Disable();
    }
}
