using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public InputActionReference triggerReference = null;

    private void Awake()
    {
        triggerReference.action.performed += OnTriggerValueChanged;
    }

    private void OnDestroy()
    {
        triggerReference.action.performed -= OnTriggerValueChanged;
    }

    private void OnTriggerValueChanged(InputAction.CallbackContext context)
    {
        float value = triggerReference.action.ReadValue<float>();
        Debug.Log(value);
    }
}
