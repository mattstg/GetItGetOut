using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hands : MonoBehaviour
{
    Animator animator;
    
    private static readonly int Trigger = Animator.StringToHash("Trigger");
    private static readonly int Grip = Animator.StringToHash("Grip");
    public float GripTarget { get; set; }
    public float TriggerTarget { get; set; }
    private float currentTrigger;
    private float currentGrip;
    public float closingHandSpeed = 1f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateHand();
    }

    private void AnimateHand()
    {
        if (currentTrigger != TriggerTarget)
        {
            currentTrigger = Mathf.MoveTowards(currentTrigger, TriggerTarget, Time.deltaTime * closingHandSpeed);
            animator.SetFloat(Trigger, currentTrigger);
        }

        if (currentGrip != GripTarget)
        {
            currentGrip = Mathf.MoveTowards(currentGrip, GripTarget, Time.deltaTime * closingHandSpeed);
            animator.SetFloat(Grip, currentGrip);
        }
    }
}
