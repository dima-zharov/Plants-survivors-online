using UnityEngine;

public class MovementJoystick : JoystickHandler
{
    [SerializeField] PlayerMovement _playerMovement;

    private void Update()
    {
        if(_inputVector.x != 0  || _inputVector.y != 0)
        {
            _playerMovement.MovePlayer(new Vector2(_inputVector.x, _inputVector.y));
        }
        else
        {
            AnimationEventManager.SendBoolParametrChanged(false, nameof(AnimParametersEnum.isRunning));
        }
    }
}
