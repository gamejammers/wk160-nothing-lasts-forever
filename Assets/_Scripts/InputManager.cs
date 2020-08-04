using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Player Object References")]
    [SerializeField] private SimplePlayerMovement playerMovement;
    [SerializeField] private GameObject reticle = null;

    [Header("Manager References")]
    [SerializeField] private TileManager tileManager;
    [SerializeField] private TimeManager timeManager;

    [Header("Input References")]
    [SerializeField] private InputActionAsset gameplayInput;
    [SerializeField] private InputActionReference shootInput, wrenchHit, wrenchBuild, jumpInput, moveInput, buildingModeInput;
    
    private void OnEnable()
    {
        // Enabling Gameplay Action Map and addind action responses
        // Also disabling Wrench Build action Reference so that you start of hitting with wrench not building with it
        Debug.Log("Enabled Input");
        gameplayInput.Enable();

        moveInput.action.performed += playerMovement.SetMoveDirection;
        moveInput.action.canceled += playerMovement.SetMoveDirection;
        // wrenchHit.action.performed += WrenchHitDebug;
        wrenchBuild.action.performed += tileManager.SetTile;

        buildingModeInput.action.started += SwitchWrenchMode;
        buildingModeInput.action.canceled += SwitchWrenchMode;

        buildingModeInput.action.started += timeManager.DoSlowmotion;
        buildingModeInput.action.canceled += timeManager.BackToNormal;

        buildingModeInput.action.started += x => reticle.SetActive(false);
        buildingModeInput.action.canceled += x => reticle.SetActive(true);

        buildingModeInput.action.started += tileManager.StartCreatingTile;
        buildingModeInput.action.canceled += tileManager.StopCreatingTile;

        wrenchBuild.action.Disable();
    }

    private void OnDisable()
    {
        // Disabling Gameplay Action Map and removing action responses
        Debug.Log("Disabled Input");
        gameplayInput.Disable();

        moveInput.action.performed -= playerMovement.SetMoveDirection;
        moveInput.action.canceled -= playerMovement.SetMoveDirection;
        // wrenchHit.action.performed -= WrenchHitDebug;
        wrenchBuild.action.performed -= tileManager.SetTile;

        buildingModeInput.action.started -= SwitchWrenchMode;
        buildingModeInput.action.canceled -= SwitchWrenchMode;

        buildingModeInput.action.started -= timeManager.DoSlowmotion;
        buildingModeInput.action.canceled -= timeManager.BackToNormal;

        buildingModeInput.action.started -= x => reticle.SetActive(false);
        buildingModeInput.action.canceled -= x => reticle.SetActive(true);

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
}