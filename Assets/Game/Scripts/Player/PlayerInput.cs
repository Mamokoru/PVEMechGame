using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, GameInputSystem.IPlayerActions
{
    private InputData _inputData = new InputData();

    public void OnAttack(InputAction.CallbackContext context)
    {
        _inputData.IsAttacking = context.ReadValueAsButton();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        _inputData.IsCouching = context.ReadValueAsButton();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _inputData.IsJumping = context.ReadValueAsButton();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _inputData.LookRotation = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputData.MoveVector = context.ReadValue<Vector2>();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        _inputData.IsRunning = context.ReadValueAsButton();
    }

    GameInputSystem SavedPlayerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SavedPlayerInput = new GameInputSystem();
        SavedPlayerInput.Player.AddCallbacks(this);
    }
    private void OnEnable()
    {
        SavedPlayerInput.Enable();
    }
    private void OnDisable()
    {
        SavedPlayerInput.Disable();
    }

    internal InputData GetInputData()
    {
        return _inputData;
    }
}
