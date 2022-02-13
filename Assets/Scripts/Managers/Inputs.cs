using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public InputActionReference leftTriggerReference = null;
    public InputActionReference leftGripReference = null;
    public InputActionReference rightTriggerReference = null;
    public InputActionReference rightGripReference = null;
    
    public Hands leftHand = null;
    public Hands rightHand = null;

    public Gun gun1 = null;
    public Gun gun2 = null;
    
    private void Awake()
    {
        leftTriggerReference.action.performed += OnLeftTriggerValueChanged;
        leftGripReference.action.performed += OnLeftGripValueChanged;
        rightTriggerReference.action.performed += OnRightTriggerValueChanged;
        rightGripReference.action.performed += OnRightGripValueChanged;
    }

    private void OnDestroy()
    {
        leftTriggerReference.action.performed -= OnLeftTriggerValueChanged;
        leftGripReference.action.performed -= OnLeftGripValueChanged;
        rightTriggerReference.action.performed -= OnRightTriggerValueChanged;
        rightGripReference.action.performed -= OnRightGripValueChanged;
    }

    private void OnLeftTriggerValueChanged(InputAction.CallbackContext context)
    {
        leftHand.TriggerTarget = leftTriggerReference.action.ReadValue<float>();
        
    }

    private void OnLeftGripValueChanged(InputAction.CallbackContext context)
    {
        leftHand.GripTarget = leftGripReference.action.ReadValue<float>();
    }
    
    private void OnRightTriggerValueChanged(InputAction.CallbackContext context)
    {
        rightHand.TriggerTarget = rightTriggerReference.action.ReadValue<float>();
    }

    private void OnRightGripValueChanged(InputAction.CallbackContext context)
    {
        rightHand.GripTarget = rightGripReference.action.ReadValue<float>();
    }
}
