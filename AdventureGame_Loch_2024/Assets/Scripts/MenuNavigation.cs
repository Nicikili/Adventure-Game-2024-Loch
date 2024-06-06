using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
	public MenuNavigation instance;

	public GameObject Timmy; //what is moved

	public bool startMenu;
	public GameObject mainMenu; //mainMenu
	public GameObject creditsMenu; //creditsMenu

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
		controls.MenuNavigation.Accept.started += ctx => ButtonPressed();
	}

	#region TimmyMovement
	public void MoveTimmyLeft()
	{
		if (startMenu)
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
	}

	void MoveTimmyRight()
	{
		if (startMenu)
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
	}
	#endregion

	#region ButtonFunctions
	void ButtonPressed()
	{
		if (TimmyLocation == 0) //Credits
		{
			if (startMenu)
			{
				creditsMenu.SetActive(true);
				mainMenu.SetActive(false);
				startMenu = false;
			}

			else
			{
				creditsMenu.SetActive(false);
				mainMenu.SetActive(true);
				startMenu = true;
			}
		}

		if (TimmyLocation == 1) //StupidCritter
		{
			controls.MenuNavigation.Disable();
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if (TimmyLocation == 2) //Exit
		{
			Application.Quit();
		}
	}
	#endregion

	public void Start()
	{
		startMenu = true;
	}

	void OnEnable()
	{
		controls.MenuNavigation.Enable();
	}

	void OnDisable()
	{
		controls.MenuNavigation.Disable();
	}
}
