using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public Action OnFireButtonPressed;
    public Action OnDashButtonPressed;
    private void Awake()
    {
        if(playerInputActions == null)
        {
            playerInputActions = new PlayerInputActions();
        }
        
        playerInputActions.Default.Enable();
    }
    private void Start()
    {
        playerInputActions.Default.Fire.performed += FireButtonPressed;
        playerInputActions.Default.Dash.performed += DashButtonPressed;
    }

    public Vector2 GetMovementVector()
    {
        Vector2 movementVector = playerInputActions.Default.Movement.ReadValue<Vector2>().normalized;
        return movementVector;
    }
    public Vector2 GetTempoVector()
    {
        Vector2 tempoVector = playerInputActions.Default.ChangeTempo.ReadValue<Vector2>();
        return tempoVector;
    }

    public void FireButtonPressed(InputAction.CallbackContext context)
    {
        OnFireButtonPressed?.Invoke();
    }
    public void DashButtonPressed(InputAction.CallbackContext context)
    {
        OnDashButtonPressed?.Invoke();
    }
}
