using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class Inputs : MonoBehaviour
{
    public InputActionReference leftTriggerReference = null;
    public InputActionReference leftGripReference = null;
    public InputActionReference leftTriggerToggle = null;
    public InputActionReference leftGripToggle = null;
    
    public InputActionReference rightTriggerReference = null;
    public InputActionReference rightTriggerToggle= null;
    public InputActionReference rightGripReference = null;
    public InputActionReference rightGripToggle = null;
    
    public Hands leftHand = null;
    public Hands rightHand = null;

    public Gun gun1 = null;
    public Gun gun2 = null;
    public Transform gun2Forward = null;
    public Transform gun1Forward = null;

    public Transform rightControllerRotation;
    public Transform leftControllerRotation;
    private bool haveGunRight = false;
    private bool haveGunLeft = false;
    
    private void Awake()
    {
        rightTriggerReference.action.performed += OnRightTriggerValueChanged;
        rightGripReference.action.performed += OnRightGripValueChanged;
        
        rightGripToggle.action.performed += OnRightGripPressed;
        rightGripToggle.action.canceled += OnRightGripCancelled;
        
        rightTriggerToggle.action.performed += OnRightTriggerPressed;
        rightTriggerToggle.action.canceled += OnRightTriggerCancelled;
        
        //left
        leftTriggerReference.action.performed += OnLeftTriggerValueChanged;
        leftGripReference.action.performed += OnLeftGripValueChanged;

        leftGripToggle.action.performed += OnLeftGripPressed;
        leftGripToggle.action.canceled += OnLeftGripCancelled;

        leftTriggerToggle.action.performed += OnLeftTriggerPressed;
        leftTriggerToggle.action.canceled += OnLeftTriggerCancelled;

    }

    private void OnDestroy()
    {
        leftTriggerReference.action.performed -= OnLeftTriggerValueChanged;
        leftGripReference.action.performed -= OnLeftGripValueChanged;
        rightTriggerReference.action.performed -= OnRightTriggerValueChanged;
        rightGripReference.action.performed -= OnRightGripValueChanged;
        rightGripToggle.action.performed -= OnRightGripPressed;
        rightTriggerToggle.action.performed -= OnRightTriggerPressed;
    }
    
    private void OnRightTriggerValueChanged(InputAction.CallbackContext context)
    {
        float rightTriggerValue_ = rightTriggerReference.action.ReadValue<float>();
        rightHand.TriggerTarget = rightTriggerValue_;
    }    
    
    private void OnRightTriggerPressed(InputAction.CallbackContext context)
    {
        if (haveGunRight)
        {
            gun2.FireBullet();
        }
    }

    private void OnRightGripValueChanged(InputAction.CallbackContext context)
    {
        rightHand.GripTarget = rightGripReference.action.ReadValue<float>();
    }

    private void OnRightGripPressed(InputAction.CallbackContext context)
    {
        Shoot(gun2, rightHand, rightControllerRotation);
        haveGunRight = true;
    }

    private void OnRightTriggerCancelled(InputAction.CallbackContext context)
    {
        gun2.DestroySpringJoint();
    }
    
    private void OnRightGripCancelled(InputAction.CallbackContext context)
    {
        haveGunRight = false;
    }
    
 

    private void Shoot(Gun gun, Hands hand, Transform rotationController)
    {
        gun.gameObject.transform.rotation = rotationController.transform.rotation;
        gun.gameObject.transform.parent = hand.gameObject.transform ;
        gun.gameObject.transform.position = hand.gameObject.transform.position;
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void OnLeftTriggerValueChanged(InputAction.CallbackContext context)
    {
        float leftTriggerValue_ = leftTriggerReference.action.ReadValue<float>();
        leftHand.TriggerTarget = leftTriggerValue_;
    }    
    
    private void OnLeftTriggerPressed(InputAction.CallbackContext context)
    {
        if (haveGunLeft)
        {
            gun1.FireBullet();
        }
    }

    private void OnLeftGripValueChanged(InputAction.CallbackContext context)
    {
        leftHand.GripTarget = leftGripReference.action.ReadValue<float>();
    }

    private void OnLeftGripPressed(InputAction.CallbackContext context)
    {
        Shoot(gun1, leftHand, leftControllerRotation);
        haveGunLeft = true;
    }

    private void OnLeftTriggerCancelled(InputAction.CallbackContext context)
    {
        gun1.DestroySpringJoint();
    }
    
    private void OnLeftGripCancelled(InputAction.CallbackContext context)
    {
        haveGunLeft = false;
    }

}
