using UnityEngine;

public class PlayerAnimationLogic : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private void Start()
    {
        AnimationEventManager.BoolParametChanged += BoolParameterChanging;
    }
    private void OnDisable()
    {
        AnimationEventManager.BoolParametChanged -= BoolParameterChanging;
    }
    private void BoolParameterChanging(bool animState, string parameterName)
    {
        _playerAnimator.SetBool(parameterName, animState);
    }
}
