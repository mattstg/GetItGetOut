using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Inputs : MonoBehaviour
{
    public InputActionReference leftTriggerReference = null;
    public InputActionReference leftGripReference = null;
    public InputActionReference rightTriggerReference = null;
    public InputActionReference rightGripReference = null;
    public InputActionReference rightGripToggle = null;
    public InputActionReference rightTriggerPressed= null;
    
    public Hands leftHand = null;
    public Hands rightHand = null;

    public Gun gun1 = null;
    public Gun gun2 = null;
    public GameObject o;

    private bool haveGun;
    private void Awake()
    {
        leftTriggerReference.action.performed += OnLeftTriggerValueChanged;
        leftGripReference.action.performed += OnLeftGripValueChanged;
        rightTriggerReference.action.performed += OnRightTriggerValueChanged;
        rightGripReference.action.performed += OnRightGripValueChanged;
        rightGripToggle.action.performed += OnRightGripPressed;
        rightGripToggle.action.canceled += OnRightGripCancelled;
        rightTriggerPressed.action.performed += OnRightTriggerPressed;
        rightTriggerPressed.action.canceled += OnRightTriggerCancelled;
    }

    private void OnDestroy()
    {
        leftTriggerReference.action.performed -= OnLeftTriggerValueChanged;
        leftGripReference.action.performed -= OnLeftGripValueChanged;
        rightTriggerReference.action.performed -= OnRightTriggerValueChanged;
        rightGripReference.action.performed -= OnRightGripValueChanged;
        rightGripToggle.action.performed -= OnRightGripPressed;
        rightTriggerPressed.action.performed -= OnRightTriggerPressed;
    }

    private void OnLeftTriggerValueChanged(InputAction.CallbackContext context)
    {
        float leftTriggerValue = leftTriggerReference.action.ReadValue<float>();
        leftHand.TriggerTarget = leftTriggerValue;

    }

    private void OnLeftGripValueChanged(InputAction.CallbackContext context)
    {
        leftHand.GripTarget = leftGripReference.action.ReadValue<float>();
    }
    
    private void OnRightTriggerValueChanged(InputAction.CallbackContext context)
    {
        float rightTriggerValue_ = rightTriggerReference.action.ReadValue<float>();
        rightHand.TriggerTarget = rightTriggerValue_;
    }    
    
    private void OnRightTriggerPressed(InputAction.CallbackContext context)
    {
        Debug.Log(string.Format("Canceled: {0}, toString {1}, contextValueType {2}, readValue {3}", context.canceled, context.ToString() ,context.valueType,context.ReadValue<float>()));
        
        if (haveGun)
        {
            gun1.FireBullet();
        }
    }

    private void OnRightGripValueChanged(InputAction.CallbackContext context)
    {
        rightHand.GripTarget = rightGripReference.action.ReadValue<float>();
    }

    private void OnRightGripPressed(InputAction.CallbackContext context)
    {
        o.transform.parent = rightHand.gameObject.transform ;
        o.transform.position = rightHand.gameObject.transform.position;
        haveGun = true;
    }

    private void OnRightTriggerCancelled(InputAction.CallbackContext context)
    {
        gun1.DestroySpringJoint();
    }
    
    private void OnRightGripCancelled(InputAction.CallbackContext context)
    {
        
    }
}
