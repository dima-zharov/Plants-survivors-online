using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoystick : JoystickHandler
{
    public Vector2 ReturnVectorDirection()
    {
        return new Vector2(_inputVector.x, _inputVector.y);
    }
}
