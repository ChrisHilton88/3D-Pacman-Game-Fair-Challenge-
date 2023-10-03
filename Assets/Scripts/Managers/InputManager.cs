using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    PlayerInputActions _playerinputActions;


    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private LookBehaviour _lookBehaviour;    



    void Awake()
    {
        _playerinputActions = new PlayerInputActions();
        _playerinputActions.Player.Enable();
        
    }

    void OnEnable()
    {
        _playerinputActions.Player.Move.performed += MovePerformed;
        _playerinputActions.Player.Move.canceled += MoveCanceled;
        _playerinputActions.Player.Look.performed += LookPerformed;
        _playerinputActions.Player.Look.canceled += Lookcanceled;
    }


    #region Actions
    void MovePerformed(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        _playerMovement.Movement(move);
    }

    void MoveCanceled(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        _playerMovement.Movement(move);
    }

    public void LookPerformed(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();    
        _lookBehaviour.Look(look);
    }

    void Lookcanceled(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();
        _lookBehaviour.Look(look);
    }
    #endregion 


    void OnDisable()
    {
        _playerinputActions.Player.Move.performed -= MovePerformed;
        _playerinputActions.Player.Move.canceled -= MoveCanceled;
        _playerinputActions.Player.Look.performed -= LookPerformed;
        _playerinputActions.Player.Look.canceled -= Lookcanceled;
    }
}
