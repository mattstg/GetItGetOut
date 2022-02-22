using System;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public InputActionReference A = null;
    public InputActionReference X = null;
    
    public Hands leftHand = null;
    public Hands rightHand = null;

    public Transform leftHolsterSnap = null;
    public Transform rightHolsterSnap = null;

    public Gun gunLeft = null;
    public Gun gunRight = null;

    public Transform gunRightForward = null;
    public Transform gunLeftForward = null;

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

        A.action.performed += OnAPerformed;
        A.action.canceled += OnACancelled;
        
        //left
        leftTriggerReference.action.performed += OnLeftTriggerValueChanged;
        leftGripReference.action.performed += OnLeftGripValueChanged;

        leftGripToggle.action.performed += OnLeftGripPressed;
        leftGripToggle.action.canceled += OnLeftGripCancelled;

        leftTriggerToggle.action.performed += OnLeftTriggerPressed;
        leftTriggerToggle.action.canceled += OnLeftTriggerCancelled;

        X.action.performed += OnXPerformed;
        X.action.canceled += OnXCancelled;
    }

    private void Update()
    {
        if (haveGunRight && A.action.ReadValue<float>() > 0.1f)
        {
            gunRight.Reeling();
        }

        if (haveGunLeft && X.action.ReadValue<float>() > 0.1f)
        {
            gunLeft.Reeling();
        }
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
            gunRight.FireBullet();
        }
    }

    private void OnRightGripValueChanged(InputAction.CallbackContext context)
    {
        rightHand.GripTarget = rightGripReference.action.ReadValue<float>();
    }

    private void OnRightGripPressed(InputAction.CallbackContext context)
    {
        Shoot(gunRight, rightHand, rightControllerRotation);
        haveGunRight = true;
        gunRight.Audio.PlayRecharge(gunRight.gameObject);
    }

    private void OnRightTriggerCancelled(InputAction.CallbackContext context)
    {
        gunRight.DestroySpringJoint();
    }
    
    private void OnRightGripCancelled(InputAction.CallbackContext context)
    {
        haveGunRight = false;
        gunRight.DestroySpringJoint();
        gunRight.transform.position = rightHolsterSnap.gameObject.transform.position;
        gunRight.transform.eulerAngles = rightHolsterSnap.gameObject.transform.eulerAngles;
        gunRight.gameObject.transform.parent = rightHolsterSnap.gameObject.transform;
        gunRight.Audio.StopAllAudio(gunRight.gameObject);
    }
    
    private void OnLeftTriggerValueChanged(InputAction.CallbackContext context)
    {
        float leftTriggerValue_ = leftTriggerReference.action.ReadValue<float>();
        leftHand.TriggerTarget = leftTriggerValue_;
    }    
    
    private void OnLeftTriggerPressed(InputAction.CallbackContext context)
    {
        if (haveGunLeft)
        {
            gunLeft.FireBullet();
        }
    }

    private void OnLeftGripValueChanged(InputAction.CallbackContext context)
    {
        leftHand.GripTarget = leftGripReference.action.ReadValue<float>();
    }

    private void OnLeftGripPressed(InputAction.CallbackContext context)
    {
        Shoot(gunLeft, leftHand, leftControllerRotation);
        haveGunLeft = true;
        gunLeft.Audio.PlayRecharge(gunLeft.gameObject);
    }

    private void OnLeftTriggerCancelled(InputAction.CallbackContext context)
    {
        gunLeft.DestroySpringJoint();
    }

    private void OnAPerformed(InputAction.CallbackContext context)
    {
        if (haveGunRight && gunRight.bullet.hit)
        {
            gunRight.Audio.PlayReelIn(gunRight.gameObject);
        }
    }
    private void OnACancelled(InputAction.CallbackContext context)
    {
        gunRight.Audio.StopReelIn(gunRight.gameObject);
    }
    private void OnXPerformed(InputAction.CallbackContext context)
    {
        if (haveGunLeft && gunLeft.bullet.hit)
        {
            gunLeft.Audio.PlayReelIn(gunLeft.gameObject);
        }
    }
    private void OnXCancelled(InputAction.CallbackContext context)
    {
        gunLeft.Audio.StopReelIn(gunLeft.gameObject);
    }
    

    private void OnLeftGripCancelled(InputAction.CallbackContext context)
    {
        haveGunLeft = false;
        gunLeft.DestroySpringJoint();
        gunLeft.transform.position = leftHolsterSnap.gameObject.transform.position;
        gunLeft.transform.eulerAngles = leftHolsterSnap.gameObject.transform.eulerAngles;
        gunLeft.gameObject.transform.parent = leftHolsterSnap.gameObject.transform;
        gunLeft.Audio.StopAllAudio(gunLeft.gameObject);
    }
    
    private void Shoot(Gun gun, Hands hand, Transform rotationController)
    {
        gun.gameObject.transform.rotation = rotationController.transform.rotation;
        gun.gameObject.transform.parent = hand.gameObject.transform ;
        gun.gameObject.transform.position = hand.gameObject.transform.position;
    }

}
