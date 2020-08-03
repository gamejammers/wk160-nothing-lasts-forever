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

    private void Awake() => gameplayInput.Enable();
    private void OnDestroy() => gameplayInput.Disable();


}