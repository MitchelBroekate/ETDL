using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationHandController : MonoBehaviour
{
    public InputActionReference gripInputActionReference;
    public InputActionReference triggerInputActionReference;

    Animator _animator;
    float _gripValue;
    float _triggerValue;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    void AnimateGrip()
    {
        _gripValue = gripInputActionReference.action.ReadValue<float>();
        _animator.SetFloat("Grip", _gripValue);
    }

    void AnimateTrigger()
    {
        _triggerValue = triggerInputActionReference.action.ReadValue<float>();
        _animator.SetFloat("Trigger", _triggerValue);
    }
}
