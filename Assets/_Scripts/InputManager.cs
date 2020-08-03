using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Player Object References")]
    [SerializeField] private SimplePlayerMovement playerMovement;

    [Header("Manager References")]
    [SerializeField] private TileManager tileManager;
    [SerializeField] private TimeManager timeManager;

    [Header("Input References")]
    [SerializeField] private InputActionAsset gameplayInput;
    [SerializeField] private InputActionReference shootInput, wrenchHit, wrenchBuild, jumpInput, moveInput, buildingModeInput;

    private void OnEnable()
    {
        Debug.Log("Enabled Input");
        gameplayInput.Enable();
        moveInput.action.performed += playerMovement.SetMoveDirection;
        moveInput.action.canceled += playerMovement.SetMoveDirection;
        wrenchHit.action.performed += WrenchHitDebug;
        wrenchBuild.action.performed += tileManager.SetTile;

        buildingModeInput.action.started += SwitchWrenchMode;
        buildingModeInput.action.canceled += SwitchWrenchMode;
        buildingModeInput.action.started += tileManager.StartCreatingTile;
        buildingModeInput.action.canceled += tileManager.StopCreatingTile;

        wrenchBuild.action.Disable();
    }

    private void OnDisable()
    {
        Debug.Log("Disabled Input");
        gameplayInput.Disable();
        moveInput.action.performed -= playerMovement.SetMoveDirection;
        moveInput.action.canceled -= playerMovement.SetMoveDirection;
        wrenchHit.action.performed -= WrenchHitDebug;
        wrenchBuild.action.performed -= tileManager.SetTile;

        buildingModeInput.action.started -= SwitchWrenchMode;
        buildingModeInput.action.canceled -= SwitchWrenchMode;
        buildingModeInput.action.started -= tileManager.StartCreatingTile;
        buildingModeInput.action.canceled -= tileManager.StopCreatingTile;
    }




    public void SwitchWrenchMode(InputAction.CallbackContext _ctx)
    {
        if (wrenchBuild.action.enabled)
        {
            wrenchBuild.action.Disable();
        }
        else
        {
            wrenchBuild.action.Enable();
        }
        if (wrenchHit.action.enabled)
        {
            wrenchHit.action.Disable();
        }
        else
        {
            wrenchHit.action.Enable();
        }
    }
    public void WrenchHitDebug(InputAction.CallbackContext _ctx) => Debug.Log($"Wrench Hit Performed!");
    public void WrenchBuildDebug(InputAction.CallbackContext _ctx) => Debug.Log($"Wrench Build Performed!");
}