using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _controls;
    private Vector2 _moveInput;
    private bool _isShooting;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }
    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }

    void Awake()
    {
        _controls = new GameControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAction(InputAction.CallbackContext playerAct)
    {
        if (playerAct.action.name == _controls.Gameplay.Shoot.name)
        {
            if (playerAct.started)
                _isShooting = true;
            else if (playerAct.canceled)
                _isShooting = false;
        }

        if (playerAct.action.name == _controls.Gameplay.Movement.name)
        {
            _moveInput = playerAct.ReadValue<Vector2>();
        }
    }
    
}
