using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Import for new input system
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    //Headers for testing inputs
    [Header("DEBUG")]
    public Vector2 _movement;



    //Creating an object of our input class
    private PlayerControls _inputActions;

    //Create an object of our sprite
    public Sprite _player;



    // Start is called before the first frame update
    void Start()
    {
        _player.Init();
    }

    //Awake is called on the first frame
    private void Awake()
    {
        _inputActions = new PlayerControls();

        //Pass our keyPresses from our input manager to our actual variables
        _inputActions.Player.Movement.performed += GetMovementInput;
        _inputActions.Player.Movement.canceled += GetMovementInput;

        //Pause or continue based on our state
        _inputActions.Player.Pause.performed += _ => PauseGame();
        _inputActions.Menu.Start.performed += _ => StartGame();


    }


    // Update is called once per frame
    void Update()
    {



 

        //pass movement from here to player
        _player._movement = _movement;

        

        _player.Tick();


    }


    //Have us be in our menu by default
    private void OnEnable()
    {
        _inputActions.Player.Enable();        
 
    }


    //When we disable, take our controls away
    private void OnDisable()
    {
        _inputActions.Menu.Disable();
        _inputActions.Player.Disable();
    }



    //Run this when we hit our start button while in menu
    public void StartGame()
    {

        Debug.Log("Starting or Resuming Game");

        _inputActions.Menu.Disable();
        _inputActions.Player.Enable();


    }


    //Use a callback to get the axis of our movement based on our buttons
    private void GetMovementInput(InputAction.CallbackContext ctx)
    {

        _movement = ctx.ReadValue<Vector2>();

    }

    //A method for when we pause our game
    public void PauseGame()
    {
        Debug.Log("Pausing Game");

        _inputActions.Menu.Enable();
        _inputActions.Player.Disable();
    }


}
