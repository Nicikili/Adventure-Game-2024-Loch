using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuNavigation : MonoBehaviour
{
	public MenuNavigation instance;

	public GameObject Timmy; //what is moved

	public bool startMenu;

	public PlayerInputActions controls;
	float JumpOffset = 330f; //add f bei Komastellen
	int TimmyLocation = 1;
	int TimmyStopLeft = 0;
	int TimmyStopRight = 2;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		controls = new PlayerInputActions();

		controls.MenuNavigation.MoveLeft.performed += ctx => MoveTimmyLeft();
		controls.MenuNavigation.MoveRight.performed += ctx => MoveTimmyRight();
	}

	public void MoveTimmyLeft()
	{
		Timmy.transform.position = new Vector3(Timmy.transform.position.x - JumpOffset, Timmy.transform.position.y, Timmy.transform.position.z); //moves line left
		TimmyLocation -= 1;
		Debug.Log(TimmyLocation);

		if (TimmyLocation == TimmyStopLeft) //stops going to far up
		{
			controls.MenuNavigation.MoveLeft.Disable();
		}

		if (TimmyLocation < 2) //enables the controls again for DOWN-Movement
		{
			controls.MenuNavigation.MoveRight.Enable();
		}
	}


	void MoveTimmyRight()
	{
		Timmy.transform.position = new Vector3(Timmy.transform.position.x + JumpOffset, Timmy.transform.position.y, Timmy.transform.position.z); //moves Line DOWN
		TimmyLocation += 1;
		Debug.Log(TimmyLocation);

		if (TimmyLocation == TimmyStopRight) //stops doing to far down
		{
			controls.MenuNavigation.MoveRight.Disable();
		}

		if (TimmyLocation > 0) //enables the controlls again for UP-Movement
		{
			controls.MenuNavigation.MoveLeft.Enable();
		}
	}

	public void Start()
	{
		startMenu = true;
	}

	void OnEnable()
	{
		controls.Enable();
	}

	void OnDisable()
	{
		controls.Disable();
	}
}
