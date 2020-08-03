using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public InputActionAsset inputMapAsset;
    public InputActionReference shotInputRef, wrenchInputRef;

    private void Awake()
    {
        inputMapAsset.Enable();
    }

    private void OnEnable()
    {
        shotInputRef.action.performed += Shoot;
        wrenchInputRef.action.performed += WrenchHit;
    }
    private void OnDisable()
    {
        shotInputRef.action.performed -= Shoot;
        wrenchInputRef.action.performed -= WrenchHit;
    }
    public void Shoot(InputAction.CallbackContext _ctx)
    {
        Debug.Log("Shot!");
    }

    public void WrenchHit(InputAction.CallbackContext _ctx)
    {
        Debug.Log("Wrench hit!");
    }
}